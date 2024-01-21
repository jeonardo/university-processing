namespace UniversityProcessing.API.Utils
{
    public class EnvironmentUtil
    {
        public static readonly bool IsDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }
}
