using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class DepartmentListSpec : BaseListSpec<Department>
{
    public DepartmentListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
        : base(["id", "name", "short_name"], pageNumber, pageSize, orderBy, desc)
    {
    }
}
