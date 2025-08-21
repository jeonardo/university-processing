using System.Security.Claims;
using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Utils.Authorization;

namespace UniversityProcessing.API.Endpoints.Common;

public interface ITokenService
{
    Token GenerateRefreshToken(IEnumerable<Claim> claims);

    Token GenerateAccessToken(IEnumerable<Claim> claims);

    RefreshTokenClaims GetRefreshTokenClaims(string token);
}
