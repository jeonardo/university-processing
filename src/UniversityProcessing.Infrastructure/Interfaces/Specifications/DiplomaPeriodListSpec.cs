using UniversityProcessing.Domain;

namespace UniversityProcessing.Infrastructure.Interfaces.Specifications;

public sealed class DiplomaPeriodListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<DiplomaProcess>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "start_date", "end_date"];
}
