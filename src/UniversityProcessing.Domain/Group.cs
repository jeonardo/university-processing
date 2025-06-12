using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

[Index(nameof(Number), IsUnique = true)]
public sealed class Group : BaseEntity, IHasId
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Number { get; private set; } = null!;

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Guid DepartmentId { get; private set; }

    public Department Department { get; private set; } = null!;
    public Guid SpecialtyId { get; private set; }
    public Specialty Specialty { get; private set; } = null!;

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Group()
    {
    }

    public static Group Create(string number, DateTime startDate, DateTime endDate, Guid specialtyId)
    {
        return new Group
        {
            Number = number,
            StartDate = startDate,
            EndDate = endDate,
            SpecialtyId = specialtyId
        };
    }
}
