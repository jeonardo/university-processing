using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.Domain.Identity;

public class UserPermission : BaseEntity
{
    public Guid UserId { get; private set; }

    public User User { get; private set; } = null!;

    public UserPermissionId UserPermissionId { get; private set; }

    public bool Active { get; private set; }

    public UserPermission(User user, UserPermissionId userPermissionId, bool active = true)
    {
        UserId = Guard.Against.Null(user).Id;
        User = Guard.Against.Null(user);
        UserPermissionId = Guard.Against.Default(userPermissionId);
        Active = active;
    }

    //Parameterless constructor used by EF Core
    protected UserPermission()
    {
    }
}