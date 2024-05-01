using Microsoft.AspNetCore.Builder;

namespace UniversityProcessing.GenericSubdomain.GlobalExceptionHandler.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMiddleware<ExceptionMiddleware>();
    }
}