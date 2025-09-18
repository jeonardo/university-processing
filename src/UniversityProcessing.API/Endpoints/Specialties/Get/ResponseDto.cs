using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Specialties.Get;

public sealed class ResponseDto(PagedList<SpecialtyDto> list) : PagedList<SpecialtyDto>(list);
