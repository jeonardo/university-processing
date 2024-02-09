namespace UniversityProcessing.API.AuthenticateEndpoints
{
    public record RefreshRequest(string Value,
                                 DateTime Expiration,
                                 string RefreshValue,
                                 DateTime RefreshExpiration) : BaseRequest;
}
