using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class UniversityPosition : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = [];
    public virtual ICollection<Deanery> Deaneries { get; set; } = [];

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
