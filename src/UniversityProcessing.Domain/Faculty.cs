using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class Faculty : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    public Guid? HeadUserId { get; private set; }

    public virtual ICollection<Department> Departments { get; private set; } = null!;

    public virtual ICollection<Student> Students { get; private set; } = null!;
    public virtual ICollection<Teacher> Teachers { get; private set; } = null!;
    public virtual ICollection<Deanery> Deaneries { get; set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Faculty()
    {
    }

    public static Faculty Create(string name, string shortName)
    {
        return new Faculty
        {
            Name = name,
            ShortName = shortName
        };
    }

    public void SetHead(Guid userId)
    {
        HeadUserId = userId;
    }
}
