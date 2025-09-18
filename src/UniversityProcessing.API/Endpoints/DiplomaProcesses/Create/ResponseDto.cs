namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Create;

public sealed class ResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
