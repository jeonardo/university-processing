using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class Department : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    public long FacultyId { get; private set; }

    public Faculty Faculty { get; private set; } = null!;

    public long? HeadUserId { get; private set; }

    public virtual ICollection<DiplomaProcess> DiplomaProcesses { get; private set; } = [];

    public virtual ICollection<Specialty> Specialties { get; private set; } = [];
    public virtual ICollection<Teacher> Teachers { get; set; } = [];
    public virtual ICollection<Student> Students { get; set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Department()
    {
    }

    public static Department Create(string name, string shortName, long facultyId)
    {
        return new Department
        {
            Name = name,
            ShortName = shortName,
            FacultyId = facultyId
        };
    }

    public void SetHead(long leaderId)
    {
        HeadUserId = leaderId;
    }
}
