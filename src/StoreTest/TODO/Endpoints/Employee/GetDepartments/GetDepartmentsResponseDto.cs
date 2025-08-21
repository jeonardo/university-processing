namespace StoreTest.TODO.Endpoints.Employee.GetDepartments;

public sealed class GetDepartmentsResponseDto(PagedList<DepartmentDto> list)
{
    public PagedList<DepartmentDto> List { get; set; } = list;
}
