using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class University : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    public Guid? AdminId { get; private set; }

    public ICollection<UniversityPosition> UniversityPositions { get; private set; } = [];

    public ICollection<Faculty> Faculties { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    public University(string name, string shortName)
    {
        Name = name;
        ShortName = shortName;
    }

    //Parameterless constructor used by EF Core
    private University()
    {
    }

    public void SetAdmin(User user)
    {
        AdminId = user.Id;
    }
}
