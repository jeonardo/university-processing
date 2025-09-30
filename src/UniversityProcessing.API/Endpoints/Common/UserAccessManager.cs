using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.Common;

internal static class UserAccessManager
{
    private static readonly Dictionary<UserRoleType, HashSet<UserRoleType>> _dictionary = new()
    {
        { UserRoleType.Admin, [UserRoleType.Admin, UserRoleType.Deanery] },
        { UserRoleType.Deanery, [UserRoleType.Deanery, UserRoleType.Student, UserRoleType.Teacher] }
    };

    public static void ThrowIfAccessToRoleIsNotAllowed(UserRoleType currentUserRole, UserRoleType selectedUserRole)
    {
        return;

        // TODO: implement when role-access will be implemented and will be known

        if (_dictionary.TryGetValue(currentUserRole, out var availableRoles) && availableRoles.Contains(selectedUserRole))
        {
            return;
        }

        throw new ConflictException("Action not allowed");
    }
}
