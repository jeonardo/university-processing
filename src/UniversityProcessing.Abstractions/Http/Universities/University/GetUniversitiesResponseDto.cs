using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversitiesResponseDto(PagedList<UniversityDto> list)
{
    public PagedList<UniversityDto> List { get; set; } = list;
}
