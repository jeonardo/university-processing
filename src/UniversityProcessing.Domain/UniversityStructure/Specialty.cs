using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Specialty : BaseEntity
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

    public Specialty(string name, string shortName, Faculty faculty, string code)
    {
        Name = name;
        ShortName = shortName;
        Code = code;
        FacultyId = faculty.Id;
        Faculty = faculty;
    }

    //Parameterless constructor used by EF Core
    private Specialty()
    {
    }
}
