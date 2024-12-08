using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class DiplomaPeriod : BaseEntity, IHasId
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? RequiredTitles { get; private set; }

    public DateTime StudyPeriodFrom { get; private set; }
    public DateTime StudyPeriodTo { get; private set; }
    public DateTime? ActiveFrom { get; private set; }
    public DateTime? ActiveTo { get; private set; }

    public Guid? СommitteeId { get; private set; }

    public Сommittee? Committee { get; private set; }

    public ICollection<Group> Groups { get; private set; } = [];

    public ICollection<Diploma> Diplomas { get; private set; } = [];
    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private DiplomaPeriod()
    {
    }

    public static DiplomaPeriod Create(DateTime startDate, DateTime endDate, string name)
    {
        return new DiplomaPeriod
        {
            StudyPeriodFrom = startDate,
            StudyPeriodTo = endDate,
            Name = name
        };
    }
}
