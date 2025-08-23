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

    public static void ThrowIfAccessToRoleIsNotAllowed(IEnumerable<UserRoleType> currentUserRoles, IEnumerable<UserRoleType> selectedUserRoles)
    {
        if (!currentUserRoles.Any(
                x => _dictionary.TryGetValue(x, out var availableRoles)
                    && selectedUserRoles.Any(availableRoles.Contains)))
        {
            throw new ConflictException("Action not allowed");
        }
    }

    public static void ThrowIfAccessToRoleIsNotAllowed(IEnumerable<UserRoleType> currentUserRoles, IEnumerable<string> selectedUserRoles)
    {
        try
        {
            ThrowIfAccessToRoleIsNotAllowed(currentUserRoles, selectedUserRoles.Select(Enum.Parse<UserRoleType>));
        }
        catch (Exception)
        {
            throw new ConflictException("Action not allowed");
        }
    }
}
