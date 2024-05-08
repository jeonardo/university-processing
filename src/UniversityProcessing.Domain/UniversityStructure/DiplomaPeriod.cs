using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class DiplomaPeriod : BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; private set; }

    public Guid FacultyId { get; }

    public Faculty Faculty { get; private set; } = null!;

    public Guid SecretaryId { get; private set; }

    public Employee Secretary { get; private set; } = null!;

    public ICollection<string> RequiredTitles { get; private set; } = [];

    public ICollection<Diploma> GraduateWorks { get; private set; } = [];

    public ICollection<Student> Students { get; private set; } = [];

    public ICollection<Employee> Employees { get; private set; } = [];

    public DiplomaPeriod(Faculty faculty, Employee secretary, DateOnly startDate, DateOnly endDate)
    {
        StartDate = Guard.Against.Default(startDate);
        EndDate = Guard.Against.Default(endDate);
        SecretaryId = Guard.Against.Null(secretary).Id;
        Secretary = Guard.Against.Null(secretary);
        FacultyId = Guard.Against.Null(faculty).Id;
        Faculty = Guard.Against.Null(faculty);
    }

    //Parameterless constructor used by EF Core
    private DiplomaPeriod()
    {
    }
}