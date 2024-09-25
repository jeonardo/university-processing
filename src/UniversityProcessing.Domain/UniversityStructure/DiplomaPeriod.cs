using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class DiplomaPeriod : BaseEntity, IHasId
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid? FacultyId { get; private set; }

    public Faculty? Faculty { get; private set; }

    public Guid? SecretaryId { get; private set; }

    public ICollection<string> RequiredTitles { get; private set; } = [];

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private DiplomaPeriod()
    {
    }

    public static DiplomaPeriod Create(DateOnly startDate, DateOnly endDate, Guid? facultyId = null)
    {
        return new DiplomaPeriod
        {
            StartDate = startDate.ToDateTime(TimeOnly.MinValue),
            EndDate = endDate.ToDateTime(TimeOnly.MinValue),
            FacultyId = facultyId
        };
    }
}
