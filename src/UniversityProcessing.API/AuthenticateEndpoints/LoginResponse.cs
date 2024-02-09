namespace UniversityProcessing.API.AuthenticateEndpoints
{
    public record LoginResponse(Guid CorrelationId) : BaseResponse(CorrelationId)
    {
    }
}
