using System.ComponentModel.DataAnnotations;
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

    [StringLength(255)]
    public string? RequiredTitles { get; private set; }

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private DiplomaPeriod()
    {
    }

    public static DiplomaPeriod Create(DateTime startDate, DateTime endDate, Guid? facultyId = null)
    {
        return new DiplomaPeriod
        {
            StartDate = startDate,
            EndDate = endDate,
            FacultyId = facultyId
        };
    }
}
