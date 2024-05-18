using UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class RefreshRequestConverter
{
    public static RefreshCommandRequest ToInternal(HttpContext httpContext)
    {
        return new RefreshCommandRequest(httpContext.Request.Headers.Authorization.ToString());
    }
}