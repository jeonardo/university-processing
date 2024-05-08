using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Employee : User, IAggregateRoot
{
    public Guid UniversityPositionId { get; private set; }

    public UniversityPosition UniversityPosition { get; private set; } = null!;

    public Guid? DepartmentId { get; private set; }

    public Department? Department { get; private set; }

    public Employee(
        UniversityPosition universityPosition,
        Department department,
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
        UniversityPositionId = Guard.Against.Null(universityPosition).Id;
        UniversityPosition = Guard.Against.Null(universityPosition);
        DepartmentId = Guard.Against.Null(department).Id;
        Department = Guard.Against.Null(department);
    }

    //Parameterless constructor used by EF Core
    private Employee()
    {
    }
}