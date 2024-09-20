using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversityPositionsResponseDto(PagedList<UniversityPositionDto> list)
{
    public PagedList<UniversityPositionDto> List { get; set; } = list;
}
