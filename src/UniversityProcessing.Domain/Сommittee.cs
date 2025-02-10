using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain;

public sealed class Сommittee : BaseEntity
{
    public ICollection<User> Users { get; private set; } = [];

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
