using UniversityProcessing.Abstractions.Http.Universities.Diploma;

namespace UniversityProcessing.Abstractions.Http.Universities.DiplomaPeriods;

public sealed class GetDiplomaPeriodResponseDto(DiplomaPeriodDto diplomaPeriod)
{
    public DiplomaPeriodDto DiplomaPeriod { get; set; } = diplomaPeriod;
}
