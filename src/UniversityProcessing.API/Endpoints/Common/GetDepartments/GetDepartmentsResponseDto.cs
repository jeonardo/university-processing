using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Common.GetDepartments;

public sealed class GetDepartmentsResponseDto(PagedList<DepartmentDto> list)
{
    public PagedList<DepartmentDto> List { get; set; } = list;
}
