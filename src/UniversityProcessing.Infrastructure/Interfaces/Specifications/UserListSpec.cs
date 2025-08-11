using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.Infrastructure.Interfaces.Specifications;

public sealed class UserListSpec(int pageNumber, int pageSize, string orderBy, bool desc)
    : BaseListSpec<User>(pageNumber, pageSize, orderBy, desc)
{
    protected override string[] AvailableProperties => ["id", "first_name", "last_name", "middle_name"];
}
