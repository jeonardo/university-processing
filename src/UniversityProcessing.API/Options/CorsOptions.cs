namespace UniversityProcessing.API.Options;

public sealed class CorsOptions
{
    public required string AllowedOrigins { get; set; }

    public string[] GetAllowedOrigins()
    {
        return AllowedOrigins.Split(";");
    }
}
