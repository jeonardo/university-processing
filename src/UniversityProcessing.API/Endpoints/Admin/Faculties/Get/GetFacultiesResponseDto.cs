using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Admin.Faculties.Get;

public sealed class GetFacultiesResponseDto(PagedList<FacultyDto> list)
{
    public PagedList<FacultyDto> List { get; set; } = list;
}
