namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Create;

public sealed class CreateDiplomaProcessResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
