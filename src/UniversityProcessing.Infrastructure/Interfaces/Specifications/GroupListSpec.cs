using UniversityProcessing.Domain;

namespace UniversityProcessing.Infrastructure.Interfaces.Specifications;

public sealed class GroupListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<Group>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "number", "start_date", "end_date"];
}
