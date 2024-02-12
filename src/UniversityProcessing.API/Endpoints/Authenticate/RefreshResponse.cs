using UniversityProcessing.Domain.API;
using UniversityProcessing.Domain.DTOs;

namespace UniversityProcessing.API.Endpoints.Authenticate
{
    public record RefreshResponse(Guid CorrelationId, Token Token) : BaseResponse(CorrelationId)
    {
    }
}
