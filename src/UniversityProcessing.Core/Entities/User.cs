using UniversityProcessing.Core.Enums;
using UniversityProcessing.Core.ValueObjects;

namespace UniversityProcessing.Core.Entities;

public abstract class User : EntityBase
{
    public PersonalName Name { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserStatus Status { get; private set; } = UserStatus.Pending;

    // Навигационные свойства (для EF Core)

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

    public Faculty? Faculty { get; private set; } // если пользователь привязан к факультету

    public Guid? FacultyId { get; private set; }

    // ... другие навигационные свойства

    private User()
    {
    } // Конструктор для EF

    protected User(PersonalName name, Email email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Status = UserStatus.PendingVerification;
    }

    // Бизнес-методы
    public void Verify()
    {
        if (Status == UserStatus.Blocked)
        {
            throw new InvalidOperationException("Blocked user cannot be verified");
        }

        Status = UserStatus.Verified;
        AddDomainEvent(new UserVerifiedEvent(Id));
    }

    public void Block()
    {
        Status = UserStatus.Blocked;
        AddDomainEvent(new UserBlockedEvent(Id));
    }

    public void AddRole(RoleType roleType)
    {
        UserRoles.Add(new UserRole(this, roleType));
    }
}
