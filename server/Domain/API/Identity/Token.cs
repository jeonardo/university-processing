namespace UniversityProcessing.API.Domain.API.Identity
{
    public record Token(string Value, DateTime Expiration, string RefreshValue, DateTime RefreshExpiration);
}
