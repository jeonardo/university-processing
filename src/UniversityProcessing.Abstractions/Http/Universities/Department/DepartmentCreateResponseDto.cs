namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class DepartmentCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}