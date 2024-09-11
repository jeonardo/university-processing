using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class University : BaseEntity, IHasId
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    public Guid? AdminId { get; private set; }

    public ICollection<Faculty> Faculties { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private University()
    {
    }

    public void Update(string? name = null, string? shortName = null, Guid? adminId = null)
    {
        Name = name ?? Name;
        ShortName = shortName ?? ShortName;
        AdminId = adminId ?? AdminId;
    }

    public static University Create(string name, string shortName, Guid? adminId = null)
    {
        return new University
        {
            Name = name,
            ShortName = shortName,
            AdminId = adminId
        };
    }
}
