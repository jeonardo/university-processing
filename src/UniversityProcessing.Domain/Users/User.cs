using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain.Users;

public class User : IdentityUser<Guid>, IAggregateRoot, IHasId
{
    public UserRoleType Role { get; private set; }
    public bool Blocked { get; private set; }
    public bool Approved { get; private set; }

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? RefreshToken { get; private set; }

    public DateTime? RefreshTokenExpiration { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public sealed override string? Email { get; set; }
    public sealed override string? PhoneNumber { get; set; }

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string FirstName { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string LastName { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? MiddleName { get; private set; }

    public DateTime? Birthday { get; private set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    protected User()
    {
    }

    protected User(
        string userName,
        string firstName,
        string lastName,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null,
        string? phoneNumber = null)
        : base(userName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
    }

    public string GetFullName()
    {
        return MiddleName is null
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}";
    }

    public void UpdateVerificationStatus(bool isApproved)
    {
        Approved = isApproved;
    }

    public void UpdateBlockingStatus(bool isBlocked)
    {
        Blocked = isBlocked;
    }

    public void UpdateRefreshToken(string refreshToken, DateTime expirationTime)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiration = expirationTime;
    }
}
