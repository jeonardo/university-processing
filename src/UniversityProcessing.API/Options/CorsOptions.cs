namespace UniversityProcessing.API.Options;

public sealed class CorsOptions
{
    public string AllowedOrigins { get; set; } = string.Empty;

    public string[] GetAllowedOrigins()
    {
        return AllowedOrigins.Split(";");
    }
}
