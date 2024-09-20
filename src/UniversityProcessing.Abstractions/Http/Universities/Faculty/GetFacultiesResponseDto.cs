using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class GetFacultiesResponseDto(PagedList<FacultyDto> list)
{
    public PagedList<FacultyDto> List { get; set; } = list;
}
