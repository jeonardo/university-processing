using UniversityProcessing.Core.Enums;

namespace UniversityProcessing.Core.Entities;

public class UserRole : EntityBase
{
    // Навигационные свойства
    public User User { get; private set; }
    public RoleType RoleType { get; private set; }

    public UserRole(
        User user,
        RoleType roleType)
    {
        User = user;
        RoleType = roleType;
    }
}
