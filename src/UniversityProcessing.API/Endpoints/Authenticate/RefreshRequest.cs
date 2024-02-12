using UniversityProcessing.Domain.API;

namespace UniversityProcessing.API.Endpoints.Authenticate
{
    public record RefreshRequest(string Value,
                                 DateTime Expiration,
                                 string RefreshValue,
                                 DateTime RefreshExpiration) : BaseRequest;
}
