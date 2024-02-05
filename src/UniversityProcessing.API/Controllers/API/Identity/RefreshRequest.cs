namespace UniversityProcessing.API.Controllers.API.Identity
{
    public record RefreshRequest(string Value,
                                 DateTime Expiration,
                                 string RefreshValue,
                                 DateTime RefreshExpiration);
}
