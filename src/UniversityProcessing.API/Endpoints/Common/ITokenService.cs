using System.Security.Claims;

namespace UniversityProcessing.API.Endpoints.Common;

public interface ITokenService
{
    string GenerateRefreshToken(out DateTime expirationTime);

    string GenerateAccessToken(IEnumerable<Claim> claims);

    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
