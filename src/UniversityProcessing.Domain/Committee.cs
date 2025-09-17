using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;

namespace UniversityProcessing.Domain;

public class Committee : BaseEntity
{
    public virtual ICollection<Teacher> Teachers { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Committee()
    {
    }

    public static Committee Create()
    {
        return new Committee();
    }
}
