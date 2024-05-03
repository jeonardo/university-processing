using UniversityProcessing.DomainServices.Features.Identity.Logout.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class LogoutRequestConverter
{
    public static LogoutCommandRequest ToInternal()
    {
        return new LogoutCommandRequest();
    }
}