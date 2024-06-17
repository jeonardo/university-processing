using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class DiplomaPeriod : BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; private set; }

    public Guid? FacultyId { get; private set; }

    public Faculty? Faculty { get; private set; }

    public Guid? SecretaryId { get; private set; }

    public ICollection<string> RequiredTitles { get; private set; } = [];

    public ICollection<Diploma> Diplomas { get; private set; } = [];

    public ICollection<User> Users { get; private set; } = [];

    public DiplomaPeriod(Faculty faculty, DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
        FacultyId = faculty.Id;
        Faculty = faculty;
    }

    //Parameterless constructor used by EF Core
    private DiplomaPeriod()
    {
    }
}
