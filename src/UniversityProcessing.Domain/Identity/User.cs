using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Domain.Identity;

//TODO mark as nullable references to prevent cascade delete
public class User : IdentityUser<Guid>, IAggregateRoot
{
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

    public Guid? UniversityId { get; private set; }

    public University? University { get; private set; }

    public Guid? GroupId { get; private set; }

    public Group? Group { get; private set; }

    public Guid? UniversityPositionId { get; private set; }

    public UniversityPosition? UniversityPosition { get; private set; }

    public Guid? FacultyId { get; private set; }

    public Faculty? Faculty { get; private set; }

    public Guid? DepartmentId { get; private set; }

    public Department? Department { get; private set; }

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<DiplomaPeriod> DiplomaPeriods { get; private set; } = [];

    public User(
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Birthday = birthday;
    }

    public User(
        Group group,
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        GroupId = group.Id;
        Group = group;

        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Birthday = birthday;
    }

    public User(
        University university,
        UniversityPosition universityPosition,
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        UniversityId = university.Id;
        University = university;
        UniversityPositionId = universityPosition.Id;
        UniversityPosition = universityPosition;

        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Birthday = birthday;
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
