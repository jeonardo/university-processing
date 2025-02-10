using UniversityProcessing.Domain;

namespace UniversityProcessing.Repository.Specifications;

public sealed class FacultyListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<Faculty>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "name", "short_name"];
}
