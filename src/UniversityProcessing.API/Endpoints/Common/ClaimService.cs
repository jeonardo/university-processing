using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Common;

public sealed class ClaimService(UserManager<User> userManager) : IClaimService
{
    public async Task<Claim[]> GetClaims(User user)
    {
        var claims = await userManager.GetClaimsAsync(user);
        var defaultClaims = GetDefaultClaims(user);
        return claims.Union(defaultClaims).ToArray();
    }

    private static IEnumerable<Claim> GetDefaultClaims(User user)
    {
        return
            new Claim[]
            {
                new(AppClaimTypes.ROLE, user.Role.ToString()),
                new(AppClaimTypes.USER_ID, user.Id.ToString()),
                new(AppClaimTypes.IS_APPROVED, user.Approved.ToString()),
                new(AppClaimTypes.IS_BLOCKED, user.Blocked.ToString())
            };
    }
}
