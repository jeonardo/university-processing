using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Student : User
{
    public Guid GroupId { get; private set; }

    public Group Group { get; private set; } = null!;

    public ICollection<Diploma> GraduateWorks { get; private set; } = [];

    public Student(
        Group group,
        string username,
        string firstName,
        string? lastName = null,
        string? middleName = null,
        string? email = null,
        DateOnly? birthday = null) : base(
        username,
        firstName,
        lastName,
        middleName,
        email,
        birthday)
    {
        GroupId = Guard.Against.Null(group).Id;
        Group = Guard.Against.Null(group);
    }

    //Parameterless constructor used by EF Core
    private Student()
    {
    }
}