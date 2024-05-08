using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class UniversityListSpec : BaseListSpec<University>
{
    public UniversityListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
        : base(["id", "name", "short_name"], pageNumber, pageSize, orderBy, desc)
    {
    }
}