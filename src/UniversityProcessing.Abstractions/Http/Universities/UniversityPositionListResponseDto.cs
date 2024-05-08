using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityPositionListResponseDto(PagedList<UniversityPositionDto> list)
{
    public PagedList<UniversityPositionDto> List { get; set; } = list;
}