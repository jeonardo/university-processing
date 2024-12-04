using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Common.GetDiplomaPeriods;

public sealed class GetDiplomaPeriodsResponseDto(PagedList<DiplomaPeriodDto> list)
{
    public PagedList<DiplomaPeriodDto> List { get; set; } = list;
}
