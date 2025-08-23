namespace UniversityProcessing.API.Middlewares.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseProtectedMiddleware(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMiddleware<ProtectedMiddleware>();
    }
}
