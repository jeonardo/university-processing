using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;

namespace UniversityProcessing.Domain;

public class Сommittee : BaseEntity
{
    public virtual ICollection<User> Users { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Сommittee()
    {
    }

    public static Сommittee Create()
    {
        return new Сommittee();
    }
}
