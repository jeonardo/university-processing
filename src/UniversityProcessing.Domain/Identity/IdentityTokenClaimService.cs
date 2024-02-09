using Ardalis.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniversityProcessing.Domain.DTOs;
using UniversityProcessing.Domain.Exceptions;

namespace UniversityProcessing.Domain.Identity
{
    public class IdentityTokenClaimService(UserManager<UserEntity> userManager) : ITokenClaimsService
    {
        public async Task<Result<Token>> RefreshAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
        {
            var principal = GetClaimsPrincipalFromExpiredToken(token);
            var email = principal.Claims.First(x => x.ValueType == "email_").Value;
            var userEntity = await userManager.FindByEmailAsync(email);

            if (userEntity is null)
                return Result.NotFound($"User with email = {email} not found!");

            if (userEntity is null
                || userEntity.RefreshToken != refreshToken
                || userEntity.RefreshTokenExpiryTimeUTC <= DateTime.UtcNow)
                return Result.Error("Refresh token is invalid or expired!");

            var newToken = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = newToken.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = newToken.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                return Result.Error(identityResult.Errors.ToString());

            return Result<Token>.Success(newToken);
        }

        public async Task<string> GetTokenAsync(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("");
            var user = await userManager.FindByNameAsync(userName);
            if (user == null) throw new UserNotFoundException(userName);
            var roles = await userManager.GetRolesAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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

        private string GenerateRefreshToken()
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
            signingCredentials: new SigningCredentials(
                                               new SymmetricSecurityKey(Convert.FromBase64String(authOptions.Key)),
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
