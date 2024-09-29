using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class SpecialtyListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<Specialty>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "name", "code"];
}
