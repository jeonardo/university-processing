using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class GetDepartmentsResponseDto(PagedList<DepartmentDto> list)
{
    public PagedList<DepartmentDto> List { get; set; } = list;
}
