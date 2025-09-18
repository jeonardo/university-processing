namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableDepartments;

public sealed class ResponseDto(DepartmentDto[] departments)
{
    public DepartmentDto[] Departments { get; set; } = departments;
}
