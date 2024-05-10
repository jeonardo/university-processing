using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Group : BaseEntity
{
    [StringLength(25, MinimumLength = 1)]
    public string Number { get; private set; } = null!;

    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; private set; }

    public Guid FacultyId { get; private set; }
    public Faculty Faculty { get; private set; } = null!;
    public Guid SpecialtyId { get; private set; }
    public Specialty Specialty { get; private set; } = null!;

    public ICollection<User> Students { get; private set; } = [];

    public Group(string groupNumber, DateOnly startDate, DateOnly endDate, Specialty specialty, Faculty faculty)
    {
        Number = Guard.Against.NullOrWhiteSpace(groupNumber);
        StartDate = Guard.Against.Default(startDate);
        EndDate = Guard.Against.Default(endDate);
        SpecialtyId = Guard.Against.Null(specialty).Id;
        Specialty = Guard.Against.Null(specialty);
        FacultyId = Guard.Against.Null(faculty).Id;
        Faculty = Guard.Against.Null(faculty);
    }

    //Parameterless constructor used by EF Core
    private Group()
    {
    }
}