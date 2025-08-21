using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class Period : BaseEntity
{
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? Comments { get; private set; }

    public virtual ICollection<DiplomaProcess> DiplomaProcesses { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Period()
    {
    }

    public static Period Create(DateTime startDate, DateTime endDate, string? comments = null)
    {
        return new Period
        {
            From = startDate,
            To = endDate,
            Comments = comments
        };
    }
}
