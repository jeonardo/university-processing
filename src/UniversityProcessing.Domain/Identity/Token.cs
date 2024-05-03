namespace UniversityProcessing.Domain.Identity;

public sealed record Token(string Value, DateTime Expiration);