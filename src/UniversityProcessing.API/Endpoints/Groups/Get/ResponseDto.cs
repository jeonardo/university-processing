using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Groups.Get;

public sealed class ResponseDto(PagedList<GroupDto> list) : PagedList<GroupDto>(list);
