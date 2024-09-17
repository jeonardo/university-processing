using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class DiplomaPeriodActualListSpec : BaseListSpec<DiplomaPeriod>
{
    public DiplomaPeriodActualListSpec(int pageNumber, int pageSize, string orderBy, bool desc, Guid userId)
        : base(["id", "start_date", "end_date"], pageNumber, pageSize, orderBy, desc)
    {
    }
}
