using UniversityProcessing.API.Domain.DTOs;

namespace UniversityProcessing.API.Domain.API.Identity
{
    public record RefreshRequest(string Value,
                                 DateTime Expiration,
                                 string RefreshValue,
                                 DateTime RefreshExpiration);
}
