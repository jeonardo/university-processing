using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

[Index(nameof(Number), IsUnique = true)]
public sealed class Group : BaseEntity, IHasId
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Number { get; private set; } = null!;

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid? SpecialtyId { get; private set; }
    public Specialty? Specialty { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Group()
    {
    }

    public static Group Create(string number, DateTime startDate, DateTime endDate, Guid? specialtyId = null)
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
