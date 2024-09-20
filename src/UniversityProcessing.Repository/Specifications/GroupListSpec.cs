using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class GroupListSpec : BaseListSpec<Group>
{
    public GroupListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
        : base(["id", "number", "start_date", "end_date"], pageNumber, pageSize, orderBy, desc)
    {
    }
}
