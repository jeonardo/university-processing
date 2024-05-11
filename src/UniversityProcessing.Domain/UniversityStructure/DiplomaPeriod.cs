using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class DiplomaPeriod : BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; private set; }

    public Guid FacultyId { get; private set; }

    public Faculty Faculty { get; private set; } = null!;

    public Guid SecretaryId { get; private set; }

    public ICollection<string> RequiredTitles { get; private set; } = [];

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    public DiplomaPeriod(Faculty faculty, User secretary, DateOnly startDate, DateOnly endDate)
    {
        StartDate = Guard.Against.Default(startDate);
        EndDate = Guard.Against.Default(endDate);
        SecretaryId = Guard.Against.Null(secretary).Id;
        FacultyId = Guard.Against.Null(faculty).Id;
        Faculty = Guard.Against.Null(faculty);
    }

    //Parameterless constructor used by EF Core
    private DiplomaPeriod()
    {
    }
}