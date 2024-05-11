using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Faculty : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    public Guid UniversityId { get; private set; }

    public University University { get; private set; } = null!;

    public ICollection<DiplomaPeriod> DiplomaPeriods { get; private set; } = [];

    public ICollection<Department> Departments { get; private set; } = [];

    public ICollection<Specialty> Specialties { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    public ICollection<Group> Groups { get; private set; } = [];

    public Faculty(string name, string shortName, University university)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        ShortName = Guard.Against.NullOrWhiteSpace(shortName, nameof(shortName));
        UniversityId = Guard.Against.Null(university).Id;
        University = Guard.Against.Null(university);
    }

    //Parameterless constructor used by EF Core
    private Faculty()
    {
    }
}