using System.Security.Claims;
using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Middlewares.Exceptions;

namespace UniversityProcessing.API.Endpoints.Common;

internal static class ClaimsPrincipalExtensions
{
    public static AuthTokenClaims GetAuthorizationTokenClaims(this ClaimsPrincipal user)
    {
        var claims = user.Claims.ToList();
        return new AuthTokenClaims(
            GetUserId(claims),
            GetUserRole(claims),
            GetUserApproved(claims),
            GetUserBlocked(claims));
    }

    public static Guid GetUserId(this IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == AppClaimTypes.USER_ID)?.Value;

        if (claimValue is null || !Guid.TryParse(claimValue, out var id))
        {
            throw new InvalidTokenException();
        }

        return id;
    }

    public static IReadOnlySet<UserRoleType> GetUserRole(this IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == AppClaimTypes.ROLE)?.Value;

        try
        {
            return claimValue!
                .Split(',')
                .Select(Enum.Parse<UserRoleType>)
                .ToHashSet();
        }
        catch (Exception)
        {
            throw new InvalidTokenException();
        }
    }

    public static bool GetUserApproved(this IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == AppClaimTypes.IS_APPROVED)?.Value;

        if (claimValue is null || !bool.TryParse(claimValue, out var role))
        {
            throw new InvalidTokenException();
        }

        return role;
    }

    public static bool GetUserBlocked(this IEnumerable<Claim> claims)
    {
        var claimValue = claims.FirstOrDefault(x => x.Type == AppClaimTypes.IS_BLOCKED)?.Value;

        if (claimValue is null || !bool.TryParse(claimValue, out var role))
        {
            throw new InvalidTokenException();
        }

        return role;
    }
}
