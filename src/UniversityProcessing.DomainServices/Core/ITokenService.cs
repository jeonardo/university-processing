using System.Security.Claims;
using UniversityProcessing.Domain;

namespace UniversityProcessing.DomainServices.Core;

public interface ITokenService
{
    Token GenerateRefreshToken(IEnumerable<Claim> claims);

    Token GenerateAccessToken(IEnumerable<Claim> claims);

    RefreshTokenClaims GetRefreshTokenClaims(string token);

    AuthTokenClaims GetAuthorizationTokenClaims(ClaimsPrincipal user);
}