using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Common;

public class ClaimService(UserManager<User> userManager) : IClaimService
{
    public async Task<Claim[]> GetClaims(User user)
    {
        var userRoles = await userManager.GetRolesAsync(user);
        var claims = await userManager.GetClaimsAsync(user);
        var defaultClaims = GetDefaultClaims(user, userRoles);
        return claims.Union(defaultClaims).ToArray();
    }

    private static IEnumerable<Claim> GetDefaultClaims(User user, IEnumerable<string> roles)
    {
        return
            roles
                .Select(role => new Claim(AppClaimTypes.ROLE, role))
                .Union(
                    new Claim[]
                    {
                        new(AppClaimTypes.USER_ID, user.Id.ToString()),
                        new(AppClaimTypes.IS_APPROVED, user.Approved.ToString()),
                        new(AppClaimTypes.IS_BLOCKED, user.Blocked.ToString())
                    });
    }
}
