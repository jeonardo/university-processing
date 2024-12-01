using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Repository.Specifications;

public sealed class UserListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<User>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "first_name", "last_name", "middle_name"];
}
