using Microsoft.Extensions.Primitives;
using UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class RefreshRequestConverter
{
    public static RefreshCommandRequest ToInternal(StringValues token)
    {
        return new RefreshCommandRequest(token.ToString());
    }
}