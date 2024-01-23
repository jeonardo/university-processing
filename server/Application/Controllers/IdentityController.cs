using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UniversityProcessing.API.Domain.API.Identity;
using UniversityProcessing.API.Domain.DTOs;
using UniversityProcessing.API.Domain.Entities;
using UniversityProcessing.API.Utils;

namespace UniversityProcessing.API.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController(IUserStore<UserEntity> userStore,
                                    SignInManager<UserEntity> signInManager,
                                    UserManager<UserEntity> userManager,
                                    AuthOptions authOptions,
                                    TokenValidationParameters tokenValidationParameters) : ControllerBase
    {
        [ValidateModel]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            var signInResult = await signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (!signInResult.Succeeded)
                return Unauthorized(TypedResults.Problem(signInResult.ToString(), statusCode: StatusCodes.Status401Unauthorized));

            var userEntity = await userManager.FindByNameAsync(request.UserName);

            if (userEntity is null)
                return NotFound($"User with email = {request.UserName} not found!");

            var token = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = token.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = token.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                return Unauthorized(identityResult.Errors);

            return Ok(token);
        }

        [ValidateModel]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var user = new UserEntity();
            var emailStore = (IUserEmailStore<UserEntity>)userStore;
            await userStore.SetUserNameAsync(user, request.UserName, CancellationToken.None);
            await emailStore.SetEmailAsync(user, request.UserName, CancellationToken.None);
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [ValidateModel]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshRequest request, CancellationToken cancellationToken = default)
        {
            var principal = GetClaimsPrincipalFromExpiredToken(request.Value);
            var email = principal.Claims.First(x => x.ValueType == "email_").Value;
            var userEntity = await userManager.FindByEmailAsync(email);

            if (userEntity is null)
                return NotFound($"User with email = {email} not found!");

            if (userEntity is null
                || userEntity.RefreshToken != request.RefreshValue
                || userEntity.RefreshTokenExpiryTimeUTC <= DateTime.UtcNow)
                return Unauthorized("Refresh token is invalid or expired!");

            var newToken = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = newToken.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = newToken.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                return Unauthorized(identityResult.Errors);

            return Ok(newToken);
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
