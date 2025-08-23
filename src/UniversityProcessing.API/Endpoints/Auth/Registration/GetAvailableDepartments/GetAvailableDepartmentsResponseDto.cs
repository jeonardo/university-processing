namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableDepartments;

public sealed class GetAvailableDepartmentsResponseDto(DepartmentDto[] departments)
{
    public DepartmentDto[] Departments { get; set; } = departments;
}
