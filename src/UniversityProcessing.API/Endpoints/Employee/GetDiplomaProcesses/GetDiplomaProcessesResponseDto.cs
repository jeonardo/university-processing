using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Employee.GetDiplomaProcesses;

public sealed class GetDiplomaProcessesResponseDto(PagedList<DiplomaProcessDto> list)
{
    public PagedList<DiplomaProcessDto> List { get; set; } = list;
}
