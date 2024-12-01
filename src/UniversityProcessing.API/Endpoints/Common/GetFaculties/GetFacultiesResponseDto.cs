using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Common.GetFaculties;

public sealed class GetFacultiesResponseDto(PagedList<FacultyDto> list)
{
    public PagedList<FacultyDto> List { get; set; } = list;
}
