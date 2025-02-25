using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class GetPeriodsResponseDto(PagedList<PeriodDto> list)
{
    public PagedList<PeriodDto> List { get; set; } = list;
}
