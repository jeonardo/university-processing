namespace UniversityProcessing.API.Endpoints;

internal static class Tags
{
    private const string BASE = "api/v1";

    public const string ADMIN = $"{BASE}/admin";
    public const string IDENTITY = $"{BASE}/identity";

    private const string REGISTRATION = $"{BASE}/registration";
    public const string REGISTRATION_ADMIN = $"{REGISTRATION}/admin";
    public const string REGISTRATION_EMPLOYEE = $"{REGISTRATION}/employee";
    public const string REGISTRATION_STUDENT = $"{REGISTRATION}/student";
}
