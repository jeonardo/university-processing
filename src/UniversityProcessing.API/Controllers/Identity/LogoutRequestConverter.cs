using UniversityProcessing.DomainServices.Features.Identity.Logout.Contracts;

namespace UniversityProcessing.API.Controllers.Identity;

internal static class LogoutRequestConverter
{
    public static LogoutCommandRequest ToInternal()
    {
        return new LogoutCommandRequest();
    }
}
