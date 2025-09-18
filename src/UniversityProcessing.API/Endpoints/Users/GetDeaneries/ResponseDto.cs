using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetDeaneries;

public sealed class ResponseDto(PagedList<DeaneryDto> list)
{
    public PagedList<DeaneryDto> List { get; set; } = list;
}
