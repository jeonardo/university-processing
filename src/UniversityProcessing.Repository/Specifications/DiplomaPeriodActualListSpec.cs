using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class DiplomaPeriodActualListSpec(int pageNumber, int pageSize, string orderBy, bool desc) : BaseListSpec<DiplomaPeriod>(
    pageNumber,
    pageSize,
    orderBy,
    desc)
{
    protected override string[] AvailableProperties => ["id", "start_date", "end_date"];
}
