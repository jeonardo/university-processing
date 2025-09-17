using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class DiplomaProcess : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? RequiredTitles { get; private set; }

    public DateTime? PossibleFrom { get; private set; }

    public DateTime? PossibleTo { get; private set; }

    public DateTime? Date { get; private set; }

    public Guid? СommitteeId { get; private set; }

    public virtual Сommittee? Committee { get; private set; }

    public Guid PeriodId { get; private set; }

    public virtual Period Period { get; private set; } = null!;

    public virtual ICollection<Student> Students { get; private set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; private set; } = null!;

    public virtual ICollection<Diploma> Diplomas { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private DiplomaProcess()
    {
    }

    public static DiplomaProcess Create(string name, Guid periodId)
    {
        return new DiplomaProcess
        {
            Name = name,
            PeriodId = periodId
        };
    }
}
