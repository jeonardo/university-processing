using UniversityProcessing.Domain.API;

namespace UniversityProcessing.API.Endpoints.Authenticate
{
    public record LoginResponse(Guid CorrelationId) : BaseResponse(CorrelationId)
    {
    }
}
