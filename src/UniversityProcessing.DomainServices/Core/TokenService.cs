using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UniversityProcessing.Domain;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Options;

namespace UniversityProcessing.DomainServices.Core;

internal sealed class TokenService(IOptions<AuthOptions> authOptions) : ITokenService
{
    private readonly AuthOptions _authOptions = authOptions.Value;

    public Token GenerateRefreshToken(IEnumerable<Claim> claims)
    {
        var expires = DateTime.UtcNow.AddMinutes(_authOptions.RefreshTokenLifetimeInMinutes);
        return GetAuthorizationToken(claims, expires, _authOptions.RefreshKey);
    }

    public Token GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var expires = DateTime.UtcNow.AddMinutes(_authOptions.AccessTokenLifetimeInMinutes);
        return GetAuthorizationToken(claims, expires, _authOptions.AccessKey);
    }

    public RefreshTokenClaims GetRefreshTokenClaims(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _authOptions.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.RefreshKey))
        };

        var claims = new JwtSecurityTokenHandler()
            .ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidTokenException();
        }

        return new RefreshTokenClaims(GetUserId(claims.Claims));
    }

    public AuthTokenClaims GetAuthorizationTokenClaims(ClaimsPrincipal user)
    {
        var claims = user.Claims.ToList();
        return new AuthTokenClaims(
            GetUserId(claims),
            GetUserRole(claims),
            GetUserEmail(claims));
    }

    private Token GetAuthorizationToken(IEnumerable<Claim> claims, DateTime expires, string key)
    {
        var token = new JwtSecurityToken(
            _authOptions.Issuer,
            claims: claims,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Convert.FromBase64String(key)),
                SecurityAlgorithms.HmacSha256));
        return new Token(new JwtSecurityTokenHandler().WriteToken(token), expires);
    }

    private static Guid GetUserId(IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (claimValue is null || !Guid.TryParse(claimValue, out var id))
        {
            throw new InvalidTokenException();
        }

        return id;
    }

    private static UserRoleId GetUserRole(IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

        if (claimValue is null || !Enum.TryParse<UserRoleId>(claimValue, out var role))
        {
            throw new InvalidTokenException();
        }

        return role;
    }

    private static string GetUserEmail(IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(claimValue))
        {
            throw new InvalidTokenException();
        }

        return claimValue;
    }
}