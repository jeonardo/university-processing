using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Department : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    public Guid? FacultyId { get; private set; }

    public Faculty? Faculty { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    public Department(string name, string shortName, Faculty faculty)
    {
        Name = name;
        ShortName = shortName;
        FacultyId = faculty?.Id;
        Faculty = faculty;
    }

    //Parameterless constructor used by EF Core
    private Department()
    {
    }
}
