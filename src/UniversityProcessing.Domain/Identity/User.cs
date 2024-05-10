using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity.Enums;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Guards;

namespace UniversityProcessing.Domain.Identity;

public class User : IdentityUser<Guid>, IAggregateRoot
{
    public UserRoleId UserRoleId { get; private set; }

    public bool Approved { get; private set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [StringLength(50, MinimumLength = 1)]
    public string FirstName { get; private set; } = null!;

    [StringLength(50, MinimumLength = 1)]
    public string? LastName { get; private set; }

    [StringLength(50, MinimumLength = 1)]
    public string? MiddleName { get; private set; }

    //Override accessor 'string? UniversityProcessing.Domain.Identity.User.Email.set' cannot change access rights
    [StringLength(50, MinimumLength = 1)]
    public sealed override string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; private set; }

    public Guid UniversityId { get; private set; }

    public University University { get; private set; } = null!;

    public Guid? GroupId { get; private set; }

    public Group? Group { get; private set; }

    public ICollection<Diploma> GraduateWorks { get; private set; } = [];

    public Guid? UniversityPositionId { get; private set; }

    public UniversityPosition? UniversityPosition { get; private set; }

    public Guid? DepartmentId { get; private set; }

    public Department? Department { get; private set; }

    public User(
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        UserRoleId = UserRoleId.ApplicationAdmin;
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NotNullAndWhiteSpace(lastName, nameof(lastName));
        MiddleName = Guard.Against.NotNullAndWhiteSpace(middleName, nameof(middleName));
        Email = Guard.Against.NotNullAndWhiteSpace(email, nameof(email));
        Birthday = birthday;
    }

    public User(
        University university,
        Group group,
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        UserRoleId = UserRoleId.Student;
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NotNullAndWhiteSpace(lastName, nameof(lastName));
        MiddleName = Guard.Against.NotNullAndWhiteSpace(middleName, nameof(middleName));
        Email = Guard.Against.NotNullAndWhiteSpace(email, nameof(email));
        Birthday = birthday;

        UniversityId = Guard.Against.Null(university).Id;
        University = Guard.Against.Null(university);
        GroupId = Guard.Against.Null(group).Id;
        Group = Guard.Against.Null(group);
    }

    public User(
        University university,
        UniversityPosition? universityPosition,
        Department? department,
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        UserRoleId = UserRoleId.Employee;
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NotNullAndWhiteSpace(lastName, nameof(lastName));
        MiddleName = Guard.Against.NotNullAndWhiteSpace(middleName, nameof(middleName));
        Email = Guard.Against.NotNullAndWhiteSpace(email, nameof(email));
        Birthday = birthday;

        UniversityId = Guard.Against.Null(university).Id;
        University = Guard.Against.Null(university);
        UniversityPositionId = Guard.Against.Null(universityPosition).Id;
        UniversityPosition = Guard.Against.Null(universityPosition);
        DepartmentId = department?.Id;
        Department = department;
    }

    //Parameterless constructor used by EF Core
    protected User()
    {
    }

    public void Approve()
    {
        Approved = true;
    }
}