using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain;

public sealed class Period : BaseEntity
{
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }
    public ICollection<DiplomaProcess> DiplomaProcesses { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Period()
    {
    }

    public static Period Create(DateTime startDate, DateTime endDate)
    {
        return new Period
        {
            From = startDate,
            To = endDate
        };
    }
}
