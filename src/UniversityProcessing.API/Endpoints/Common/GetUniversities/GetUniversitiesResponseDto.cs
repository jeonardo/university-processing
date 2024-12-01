using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Common.GetUniversities;

public sealed class GetUniversitiesResponseDto(PagedList<UniversityDto> list)
{
    public PagedList<UniversityDto> List { get; set; } = list;
}
