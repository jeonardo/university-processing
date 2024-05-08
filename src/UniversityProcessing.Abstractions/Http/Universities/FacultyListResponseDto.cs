using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class FacultyListResponseDto(PagedList<FacultyDto> list)
{
    public PagedList<FacultyDto> List { get; set; } = list;
}