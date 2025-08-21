using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.GetDiplomaProcesses;

public sealed class GetDiplomaProcessesResponseDto(PagedList<DiplomaProcessDto> list)
{
    public PagedList<DiplomaProcessDto> List { get; set; } = list;
}
