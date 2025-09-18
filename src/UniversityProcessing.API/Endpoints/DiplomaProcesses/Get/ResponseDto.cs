using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Get;

public sealed class ResponseDto(PagedList<DiplomaProcessDto> list) : PagedList<DiplomaProcessDto>(list);
