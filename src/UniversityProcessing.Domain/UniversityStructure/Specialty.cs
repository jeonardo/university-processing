using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

[Index(nameof(Code), IsUnique = true)]
public sealed class Specialty : BaseEntity, IHasId
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    [StringLength(12, MinimumLength = 12)]
    public string Code { get; private set; } = null!;

    public Guid? FacultyId { get; private set; }

    public Faculty? Faculty { get; private set; }

    public ICollection<Group> Groups { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Specialty()
    {
    }

    public static Specialty Create(string name, string shortName, string code, Guid? facultyId = null)
    {
        return new Specialty
        {
            Name = name,
            ShortName = shortName,
            Code = code,
            FacultyId = facultyId
        };
    }
}
