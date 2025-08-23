using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.API.Options;
using UniversityProcessing.Utils.Authorization;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.Common;

internal sealed class TokenService(IOptions<AuthSettings> authOptions, ILogger<TokenService> logger) : ITokenService
{
    private readonly AuthSettings _authSettings = authOptions.Value;

    public Token GenerateRefreshToken(IEnumerable<Claim> claims)
    {
        var expires = DateTime.UtcNow.AddMinutes(_authSettings.RefreshTokenLifetimeInMinutes);
        return GetAuthorizationToken(claims, expires, _authSettings.RefreshKey);
    }

    public Token GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var expires = DateTime.UtcNow.AddMinutes(_authSettings.AccessTokenLifetimeInMinutes);
        return GetAuthorizationToken(claims, expires, _authSettings.AccessKey);
    }

    public RefreshTokenClaims GetRefreshTokenClaims(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _authSettings.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.RefreshKey))
        };

        try
        {
            var claims = new JwtSecurityTokenHandler()
                .ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidTokenException();
            }

            return new RefreshTokenClaims(claims.Claims.GetUserId());
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error validating token");
            throw new InvalidTokenException();
        }
    }

    private Token GetAuthorizationToken(IEnumerable<Claim> claims, DateTime expires, string key)
    {
        var token = new JwtSecurityToken(
            _authSettings.Issuer,
            claims: claims,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Convert.FromBase64String(key)),
                SecurityAlgorithms.HmacSha256));
        return new Token(new JwtSecurityTokenHandler().WriteToken(token), expires);
    }
}
