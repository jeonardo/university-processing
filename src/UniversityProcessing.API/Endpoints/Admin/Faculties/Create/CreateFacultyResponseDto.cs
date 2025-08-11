namespace UniversityProcessing.API.Endpoints.Admin.Faculties.Create;

public sealed class CreateFacultyResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
