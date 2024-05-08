using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class DepartmentListResponseDto(PagedList<DepartmentDto> list)
{
    public PagedList<DepartmentDto> List { get; set; } = list;
}