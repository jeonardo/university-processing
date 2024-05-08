namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class DepartmentGetResponseDto(DepartmentDto department)
{
    public DepartmentDto Department { get; set; } = department;
}