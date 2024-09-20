using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversitiesResponseDto
{
    public PagedList<UniversityDto> List { get; set; }

    public GetUniversitiesResponseDto(PagedList<UniversityDto> list)
    {
        List = list;
    }
}
