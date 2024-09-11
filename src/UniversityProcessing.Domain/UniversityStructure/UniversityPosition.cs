using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class UniversityPosition : BaseEntity, IHasId
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private UniversityPosition()
    {
    }

    public static UniversityPosition Create(string name)
    {
        return new UniversityPosition
        {
            Name = name
        };
    }
}
