using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.GenericSubdomain.Guards;

namespace UniversityProcessing.Domain.Identity;

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

    public User(
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(username)
    {
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NotNullAndWhiteSpace(lastName, nameof(lastName));
        MiddleName = Guard.Against.NotNullAndWhiteSpace(middleName, nameof(middleName));
        Email = Guard.Against.NotNullAndWhiteSpace(email, nameof(email));
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