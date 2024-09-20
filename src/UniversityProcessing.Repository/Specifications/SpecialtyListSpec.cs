using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class SpecialtyListSpec : BaseListSpec<Specialty>
{
    public SpecialtyListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
        : base(["id", "name", "code"], pageNumber, pageSize, orderBy, desc)
    {
    }
}
