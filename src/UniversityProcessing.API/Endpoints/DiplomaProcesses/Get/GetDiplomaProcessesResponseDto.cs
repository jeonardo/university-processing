using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Get;

public sealed class GetDiplomaProcessesResponseDto(PagedList<DiplomaProcessDto> list) : PagedList<DiplomaProcessDto>(list);
