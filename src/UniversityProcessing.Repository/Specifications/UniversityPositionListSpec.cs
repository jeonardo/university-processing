using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class UniversityPositionListSpec : BaseListSpec<UniversityPosition>
{
    public UniversityPositionListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
        : base(["id", "name"], pageNumber, pageSize, orderBy, desc)
    {
    }
}