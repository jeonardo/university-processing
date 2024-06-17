using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Faculty : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    public Guid? UniversityId { get; private set; }

    public University? University { get; private set; }

    public ICollection<DiplomaPeriod> DiplomaPeriods { get; private set; } = [];

    public ICollection<Department> Departments { get; private set; } = [];

    public ICollection<Specialty> Specialties { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    public ICollection<Group> Groups { get; private set; } = [];

    public Faculty(string name, string shortName, University university)
    {
        Name = name;
        ShortName = shortName;
        UniversityId = university?.Id;
        University = university;
    }

    //Parameterless constructor used by EF Core
    private Faculty()
    {
    }
}
