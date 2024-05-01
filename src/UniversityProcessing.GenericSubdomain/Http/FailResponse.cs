namespace UniversityProcessing.GenericSubdomain.Http;

public sealed class FailResponse(string message) : BaseResponse(false, message);