using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class UniversityPosition : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
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
