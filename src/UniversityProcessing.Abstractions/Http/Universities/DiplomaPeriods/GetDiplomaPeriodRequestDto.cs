using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.DiplomaPeriods;

public sealed class GetDiplomaPeriodRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
