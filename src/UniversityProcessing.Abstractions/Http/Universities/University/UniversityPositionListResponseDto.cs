using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityPositionListResponseDto(PagedList<UniversityPositionDto> list)
{
    public PagedList<UniversityPositionDto> List { get; set; } = list;
}