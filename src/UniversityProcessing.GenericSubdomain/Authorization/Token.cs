namespace UniversityProcessing.GenericSubdomain.Authorization;

public sealed record Token(string Value, DateTime Expiration);
