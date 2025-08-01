using Microsoft.AspNetCore.Identity;

namespace UniversityProcessing.GenericSubdomain.Identity;

public static class IdentityResultExtensions
{
    public static bool IsFailed(this IdentityResult result)
    {
        return !result.Succeeded;
    }

    public static string FullDescription(this IdentityResult result)
    {
        return string.Join("; ", result.Errors.Select(x => x.Description));
    }

    public static bool IsFailed(this SignInResult result)
    {
        return !result.Succeeded;
    }
}
