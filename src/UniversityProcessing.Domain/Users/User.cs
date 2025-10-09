using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain.Users;

[Index(nameof(FullName))]
public class User : IdentityUser<long>, IAggregateRoot, IHasId
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

    [StringLength(ValidationConstants.MAX_STRING_LENGTH * 3)]
    public string FullName { get; private set; } = null!;

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
        UserRoleType role,
        string userName,
        string firstName,
        string lastName,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null,
        string? phoneNumber = null)
        : base(userName)
    {
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        FullName = GetFullName();
    }

    private string GetFullName()
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
