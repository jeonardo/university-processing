using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityListResponseDto
{
    public PagedList<UniversityDto> List { get; set; }

    public UniversityListResponseDto(PagedList<UniversityDto> list)
    {
        List = list;
    }
}