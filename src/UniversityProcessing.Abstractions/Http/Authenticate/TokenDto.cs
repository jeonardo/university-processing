namespace UniversityProcessing.Abstractions.Http.Authenticate;

public sealed class TokenDto(string value, DateTime expiration)
{
    public string Value { get; init; } = value;
    public DateTime Expiration { get; init; } = expiration;
}