using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class Department : BaseEntity, IHasId
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    public Guid FacultyId { get; private set; }

    public Faculty Faculty { get; private set; } = null!;

    public Guid? HeadUserId { get; private set; }

    public virtual ICollection<DiplomaProcess> DiplomaProcesses { get; private set; } = null!;

    public virtual ICollection<Specialty> Specialties { get; private set; } = null!;
    public virtual ICollection<Teacher> Teachers { get; set; } = null!;
    public virtual ICollection<Student> Students { get; set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Department()
    {
    }

    public static Department Create(string name, string shortName, Guid facultyId)
    {
        return new Department
        {
            Name = name,
            ShortName = shortName,
            FacultyId = facultyId
        };
    }

    public void SetLeader(Guid leaderId)
    {
        HeadUserId = leaderId;
    }
}
