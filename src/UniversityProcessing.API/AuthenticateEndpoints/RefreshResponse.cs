namespace UniversityProcessing.API.AuthenticateEndpoints
{
    public record RefreshResponse(Guid CorrelationId) : BaseResponse(CorrelationId)
    {
    }
}
