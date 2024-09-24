using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.DiplomaPeriods;

public sealed class GetActualDiplomaPeriodsResponseDto(PagedList<DiplomaPeriodDto> list)
{
    public PagedList<DiplomaPeriodDto> List { get; set; } = list;
}
