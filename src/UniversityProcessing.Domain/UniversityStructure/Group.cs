using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Group : BaseEntity, IHasId
{
    [StringLength(25, MinimumLength = 1)]
    public string Number { get; private set; } = null!;

    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; private set; }

    public Guid? SpecialtyId { get; private set; }
    public Specialty? Specialty { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Group()
    {
    }

    public static Group Create(string number, DateOnly startDate, DateOnly endDate, Guid? specialtyId = null)
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
