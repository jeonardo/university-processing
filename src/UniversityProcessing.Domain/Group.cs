using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

[Index(nameof(Number), IsUnique = true)]
public class Group : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Number { get; private set; } = null!;

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid SpecialtyId { get; private set; }
    public virtual Specialty Specialty { get; private set; } = null!;
    public Guid PeriodId { get; private set; }

    public virtual Period Period { get; private set; } = null!;
    public virtual ICollection<Student> Students { get; private set; } = null!;
    public Guid? DiplomaProcessId { get; private set; }
    public virtual DiplomaProcess DiplomaProcess { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Group()
    {
    }

    public static Group Create(string number, DateTime startDate, DateTime endDate, Guid specialtyId, Guid periodId)
    {
        return new Group
        {
            Number = number,
            StartDate = startDate,
            EndDate = endDate,
            SpecialtyId = specialtyId,
            PeriodId = periodId
        };
    }
}
