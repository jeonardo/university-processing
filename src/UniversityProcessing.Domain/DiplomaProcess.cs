using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class DiplomaProcess : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? RequiredTitles { get; private set; }

    public DateTime? PossibleFrom { get; private set; }

    public DateTime? PossibleTo { get; private set; }

    public DateTime? Date { get; private set; }

    public Guid? СommitteeId { get; private set; }

    public Сommittee? Committee { get; private set; }

    public Guid? PeriodId { get; private set; }

    public Period? Period { get; private set; }

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

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
