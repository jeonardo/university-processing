using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

[Index(nameof(Code), IsUnique = true)]
public class Specialty : BaseEntity
{
    public const int CODE_LENGTH = 12;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    [StringLength(CODE_LENGTH, MinimumLength = CODE_LENGTH)]
    public string Code { get; private set; } = null!;

    public long DepartmentId { get; private set; }

    public virtual Department Department { get; private set; } = null!;

    public virtual ICollection<Group> Groups { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Specialty()
    {
    }

    public static Specialty Create(string name, string shortName, string code, long departmentId)
    {
        return new Specialty
        {
            Name = name,
            ShortName = shortName,
            Code = code,
            DepartmentId = departmentId
        };
    }
}
