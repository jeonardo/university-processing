namespace UniversityProcessing.GenericSubdomain.Http;

public sealed class FailResponseDto(string message)
{
    public string Message { get; set; } = message;
}
