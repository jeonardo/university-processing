using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class Period : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    public DateTime From { get; private set; }
    public DateTime To { get; private set; }

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? Comments { get; private set; }

    public virtual ICollection<Group> Groups { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Period()
    {
    }

    public static Period Create(string name, DateTime startDate, DateTime endDate, string? comments = null)
    {
        return new Period
        {
            Name = name,
            From = startDate,
            To = endDate,
            Comments = comments
        };
    }
}
