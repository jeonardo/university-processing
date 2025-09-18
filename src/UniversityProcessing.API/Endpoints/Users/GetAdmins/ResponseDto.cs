using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetAdmins;

public sealed class ResponseDto(PagedList<AdminDto> list)
{
    public PagedList<AdminDto> List { get; set; } = list;
}
