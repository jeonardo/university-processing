using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetAdmins;

public sealed class GetAdminsResponseDto(PagedList<AdminDto> list)
{
    public PagedList<AdminDto> List { get; set; } = list;
}
