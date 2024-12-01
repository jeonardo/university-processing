namespace UniversityProcessing.API.Endpoints.Admin.Departments.Create;

public sealed class CreateDepartmentResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
