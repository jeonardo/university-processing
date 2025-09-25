using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;

namespace UniversityProcessing.Domain;

public class DefenseSession : BaseEntity
{
    public DateTime? Date { get; private set; }
    public Guid CommitteeId { get; private set; }
    public virtual Committee Committee { get; private set; } = null!;
    public virtual ICollection<Student> Students { get; private set; } = null!;

    public static DefenseSession Create(Guid committeeId)
    {
        return new DefenseSession
        {
            CommitteeId = committeeId
        };
    }
}
