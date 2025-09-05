using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class GetPeriodsResponseDto(PagedList<PeriodDto> list) : PagedList<PeriodDto>(list);
