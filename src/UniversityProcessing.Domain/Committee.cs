using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

// Virtual parameters used by EF Core
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
public class Committee : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    public Guid DiplomaProcessId { get; private set; }

    public Guid? SecretaryId { get; private set; }
    public virtual DiplomaProcess DiplomaProcess { get; private set; } = null!;
    public virtual ICollection<Group> Groups { get; private set; } = [];
    public virtual ICollection<Teacher> Teachers { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Committee()
    {
    }

    public static Committee Create(Guid diplomaProcessId, string name)
    {
        return new Committee
        {
            DiplomaProcessId = diplomaProcessId,
            Name = name
        };
    }
}
