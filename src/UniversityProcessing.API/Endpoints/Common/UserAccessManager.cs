using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Middlewares.Exceptions;

namespace UniversityProcessing.API.Endpoints.Common;

internal static class UserAccessManager
{
    private static readonly Dictionary<UserRoleType, HashSet<UserRoleType>> _dictionary = new()
    {
        { UserRoleType.Admin, [UserRoleType.Admin, UserRoleType.Deanery] },
        { UserRoleType.Deanery, [UserRoleType.Deanery, UserRoleType.Student, UserRoleType.Teacher] }
    };

    public static void ThrowIfRoleIsNotAllowed(UserRoleType userRoleType, UserRoleType selectedRole)
    {
        if (_dictionary.TryGetValue(userRoleType, out var availableRoles) && availableRoles.Contains(selectedRole))
        {
            return;
        }

        throw new ConflictException("Action not allowed");
    }
}
