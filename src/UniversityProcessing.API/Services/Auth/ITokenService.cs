using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using UniversityProcessing.GenericSubdomain.Authorization;

namespace UniversityProcessing.API.Services.Auth;

public interface ITokenService
{
    Token GenerateRefreshToken(IEnumerable<Claim> claims);

    Token GenerateAccessToken(IEnumerable<Claim> claims);

    RefreshTokenClaims GetRefreshTokenClaims(string token);

    AuthTokenClaims GetAuthorizationTokenClaims(ClaimsPrincipal user);

    bool TryGetAuthorizationTokenClaims(ClaimsPrincipal user, [NotNullWhen(true)] out AuthTokenClaims? claims);
}
