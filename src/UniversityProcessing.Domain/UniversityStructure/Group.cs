using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Group : BaseEntity
{
    [StringLength(25, MinimumLength = 1)]
    public string Number { get; private set; } = null!;

    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; private set; }

    public Guid? FacultyId { get; private set; }
    public Faculty? Faculty { get; private set; }
    public Guid? SpecialtyId { get; private set; }
    public Specialty? Specialty { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    public Group(string groupNumber, DateOnly startDate, DateOnly endDate, Specialty specialty)
    {
        Number = groupNumber;
        StartDate = startDate;
        EndDate = endDate;
        SpecialtyId = specialty.Id;
        Specialty = specialty;
        FacultyId = specialty.Faculty?.Id;
        Faculty = specialty.Faculty;
    }

    //Parameterless constructor used by EF Core
    private Group()
    {
    }
}
