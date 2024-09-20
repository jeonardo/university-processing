namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class CreateDepartmentResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
