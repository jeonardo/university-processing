namespace StoreTest.Admin.Faculties.Get;

public sealed class GetFacultiesResponseDto(IEnumerable<FacultyDto> items, int count, int currentPage, int pageSize)
    : PagedList<FacultyDto>(items, count, currentPage, pageSize);
