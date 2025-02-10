using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

[Index(nameof(Code), IsUnique = true)]
public sealed class Specialty : BaseEntity
{
    public const int CODE_LENGTH = 12;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    [StringLength(CODE_LENGTH, MinimumLength = CODE_LENGTH)]
    public string Code { get; private set; } = null!;

    public Guid? DepartmentId { get; private set; }

    public Department? Department { get; private set; }

    public ICollection<Group> Groups { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Specialty()
    {
    }

    public static Specialty Create(string name, string shortName, string code, Guid? departmentId = null)
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
