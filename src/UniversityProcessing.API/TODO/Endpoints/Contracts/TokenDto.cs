namespace UniversityProcessing.API.TODO.Endpoints.Contracts;

public sealed class TokenDto(string value, DateTime expiration)
{
    public string Value { get; set; } = value;
    public DateTime Expiration { get; set; } = expiration;
}
