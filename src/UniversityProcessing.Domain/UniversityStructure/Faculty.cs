using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Faculty : BaseEntity, IHasId
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

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Faculty()
    {
    }

    public static Faculty Create(string name, string shortName, Guid? universityId = null)
    {
        return new Faculty
        {
            Name = name,
            ShortName = shortName,
            UniversityId = universityId
        };
    }
}
