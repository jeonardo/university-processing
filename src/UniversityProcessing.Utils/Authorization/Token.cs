namespace UniversityProcessing.Utils.Authorization;

public sealed record Token(string Value, DateTime Expiration);
