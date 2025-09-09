using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Groups.Get;

public sealed class GetGroupsResponseDto(PagedList<GroupDto> list) : PagedList<GroupDto>(list);
