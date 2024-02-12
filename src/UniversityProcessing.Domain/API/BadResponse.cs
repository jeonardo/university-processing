namespace UniversityProcessing.Domain.API
{
    public record BadResponse : BaseResponse
    {
        public BadResponse(Guid correlationId, int statusCode, string message) : base(correlationId)
        {
            SetErrorResult(statusCode, message);
        }
    }
}
