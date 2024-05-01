using UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class RefreshRequestConverter
{
    public static RefreshCommandRequest ToInternal(string token)
    {
        return new RefreshCommandRequest(token);
    }
}