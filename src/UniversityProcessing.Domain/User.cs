using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class User : IdentityUser<Guid>, IAggregateRoot, IHasId
{
    public bool Blocked { get; private set; }
    public bool Approved { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string FirstName { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string LastName { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? MiddleName { get; private set; }

    public DateTime? Birthday { get; private set; }

    public Guid GroupId { get; private set; }

    public Group Group { get; private set; } = null!;

    public Guid? UniversityPositionId { get; private set; }

    public UniversityPosition? UniversityPosition { get; private set; }

    public Guid FacultyId { get; private set; }

    public Faculty Faculty { get; private set; } = null!;

    public Guid DepartmentId { get; private set; }

    public Department Department { get; private set; } = null!;

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<DiplomaProcess> DiplomaProcesses { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private User()
    {
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

    public static User CreateAdmin(
        string userName,
        string firstName,
        string lastName,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null)
    {
        return new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Email = email,
            Birthday = birthday
        };
    }

    public static User CreateStudent(
        string userName,
        string firstName,
        string lastName,
        Guid facultyId,
        Guid departmentId,
        Guid groupId,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null)
    {
        return new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Email = email,
            Birthday = birthday,
            GroupId = groupId,
            FacultyId = facultyId,
            DepartmentId = departmentId
        };
    }

    public static User CreateDeanery(
        string userName,
        string firstName,
        string lastName,
        Guid facultyId,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null)
    {
        return new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Email = email,
            Birthday = birthday,
            FacultyId = facultyId
        };
    }

    public static User CreateTeacher(
        string userName,
        string firstName,
        string lastName,
        Guid facultyId,
        Guid departmentId,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null,
        Guid? universityPositionId = null)
    {
        return new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Email = email,
            Birthday = birthday,
            UniversityPositionId = universityPositionId,
            FacultyId = facultyId,
            DepartmentId = departmentId
        };
    }
}
