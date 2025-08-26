using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UniversityProcessing.API.Options;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.Common;

internal sealed class TokenService(IOptions<AuthSettings> authOptions, ILogger<TokenService> logger) : ITokenService
{
    private readonly AuthSettings _authSettings = authOptions.Value;

    public string GenerateRefreshToken(out DateTime expirationTime)
    {
        expirationTime = DateTime.UtcNow.AddMinutes(_authSettings.RefreshTokenLifetimeInMinutes);
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Convert.FromBase64String(_authSettings.AccessKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(_authSettings.AccessTokenLifetimeInMinutes);
        var token = new JwtSecurityToken(_authSettings.Issuer, claims: claims, expires: expires, signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Convert.FromBase64String(_authSettings.AccessKey));
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _authSettings.Issuer,
            IssuerSigningKey = symmetricSecurityKey
        };

        try
        {
            var claims = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is JwtSecurityToken jwtSecurityToken
                && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return claims;
            }

            throw new InvalidTokenException();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error validating token");
            throw new InvalidTokenException();
        }
    }
}
