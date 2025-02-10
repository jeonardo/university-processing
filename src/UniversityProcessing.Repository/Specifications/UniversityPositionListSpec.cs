using UniversityProcessing.Domain;

namespace UniversityProcessing.Repository.Specifications;

public sealed class UniversityPositionListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<UniversityPosition>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "name"];
}
