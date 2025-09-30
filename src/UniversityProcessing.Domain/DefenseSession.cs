using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class DefenseSession : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    public DateTime Date { get; private set; }
    public Guid CommitteeId { get; private set; }
    public virtual Committee Committee { get; private set; } = null!;
    public Guid DiplomaProcessId { get; private set; }
    public virtual DiplomaProcess DiplomaProcess { get; private set; } = null!;
    public virtual ICollection<Student> Students { get; private set; } = [];

    public static DefenseSession Create(Guid committeeId, string name, Guid diplomaProcessId, DateTime date)
    {
        return new DefenseSession
        {
            CommitteeId = committeeId,
            Name = name,
            DiplomaProcessId = diplomaProcessId,
            Date = date
        };
    }
}
