using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class DepartmentListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<Department>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "name", "short_name"];
}
