﻿namespace UniversityProcessing.API.Domain.DTOs
{
    public record Token(string Value,
                        DateTime Expiration,
                        string RefreshValue,
                        DateTime RefreshExpiration);
}
