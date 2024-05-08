using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class SpecialtyListResponseDto(PagedList<SpecialtyDto> list)
{
    public PagedList<SpecialtyDto> List { get; set; } = list;
}