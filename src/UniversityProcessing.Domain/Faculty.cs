using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class Faculty : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    public Guid? HeadUserId { get; private set; }

    public ICollection<Department> Departments { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

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
