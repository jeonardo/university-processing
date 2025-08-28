using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Faculties.Get;

public sealed class GetFacultiesResponseDto(PagedList<FacultyDto> list) : PagedList<FacultyDto>(list);
