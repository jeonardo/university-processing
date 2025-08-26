namespace UniversityProcessing.API.Endpoints.Faculties.Create;

public sealed class CreateFacultyResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
