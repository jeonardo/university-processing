namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class GetDepartmentResponseDto(DepartmentDto department)
{
    public DepartmentDto Department { get; set; } = department;
}
