using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniversityProcessing.Domain.DTOs;
using UniversityProcessing.Domain.Exceptions;

namespace UniversityProcessing.Domain.Identity
{
    public class IdentityTokenClaimService(UserManager<UserEntity> userManager,
                                           SignInManager<UserEntity> signInManager,
                                           TokenValidationParameters tokenValidationParameters,
                                           AuthOptions authOptions)
        : ITokenClaimsService
    {

        public async Task<Token> GetTokenAsync(string userName, string password, CancellationToken cancellationToken = default)
        {
            var userEntity = await userManager.FindByNameAsync(userName)
                ?? throw new UserNotFoundException.ByUserName(userName);

            var signInResult = await signInManager.PasswordSignInAsync(userEntity, password, false, false);

            if (!signInResult.Succeeded)
                throw new HandledException(HttpStatusCode.Unauthorized, signInResult.ToString());

            var token = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = token.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = token.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                throw new HandledException(HttpStatusCode.Unauthorized, string.Join(", ", identityResult.Errors));

            return token;
        }

        public async Task<Token> RefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            var principal = GetClaimsPrincipalFromExpiredToken(token);
            var email = principal.Claims.First(x => x.ValueType == "email_").Value;

            var userEntity = await userManager.FindByEmailAsync(email)
                ?? throw new UserNotFoundException.ByEmail(email);

            if (userEntity.RefreshToken != refreshToken
                || userEntity.RefreshTokenExpiryTimeUTC <= DateTime.UtcNow)
                throw new RefreshTokenInvalidException();

            var newToken = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = newToken.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = newToken.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                throw new HandledException(HttpStatusCode.BadRequest,
                                           identityResult.Errors.ToString() ?? string.Empty);

            return newToken;
        }

        private Token GenerateAccessToken(UserEntity userEntity)
        {
            var claims = new Claim[]
            {
                new ("id_", userEntity.Id.ToString()),
                new ("email_", userEntity.Email!),
                new ("userName_", userEntity.UserName!)
            };

            return GenerateAccessToken(claims);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private Token GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var exp = DateTime.UtcNow.AddMinutes(authOptions.LifetimeMinutes);
            var refreshExp = DateTime.UtcNow.AddMinutes(authOptions.RefreshLifetimeMinutes);
            var jwt = new JwtSecurityToken(issuer: authOptions.ValidIssuer,
                                           audience: authOptions.ValidAudience,
                                           claims: claims,
                                           expires: exp,
                                           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(authOptions.Key)),
                                                                                      SecurityAlgorithms.HmacSha256));
            return new Token(new JwtSecurityTokenHandler().WriteToken(jwt), exp, GenerateRefreshToken(), refreshExp);
        }

        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            var principals = new JwtSecurityTokenHandler()
                .ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principals;
        }
    }

}
