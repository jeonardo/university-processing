using Microsoft.AspNetCore.Builder;

namespace UniversityProcessing.GenericSubdomain.CorrelationId.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCorrelationIdMiddleware(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMiddleware<CorrelationIdMiddleware>();
    }
}