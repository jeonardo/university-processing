using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class Department : BaseEntity, IHasId
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    public Guid FacultyId { get; private set; }

    public Faculty Faculty { get; private set; } = null!;

    public Guid? HeadUserId { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    public ICollection<DiplomaProcess> DiplomaProcesses { get; private set; } = [];

    public ICollection<Specialty> Specialties { get; private set; } = [];

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
