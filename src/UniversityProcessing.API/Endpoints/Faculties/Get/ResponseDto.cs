using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Faculties.Get;

public sealed class ResponseDto(PagedList<FacultyDto> list) : PagedList<FacultyDto>(list);
