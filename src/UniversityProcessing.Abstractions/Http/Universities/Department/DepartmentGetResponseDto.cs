namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class DepartmentGetResponseDto(DepartmentDto department)
{
    public DepartmentDto Department { get; set; } = department;
}