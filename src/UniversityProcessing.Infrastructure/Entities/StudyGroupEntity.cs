using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Entities.Base;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class StudyGroupEntity : BaseEntity, IAggregateRoot
{
    public required string GroupNumber { get; set; }

    [DataType(DataType.Date)]
    public required DateOnly StartDate { get; set; }

    [DataType(DataType.Date)]
    public required DateOnly EndDate { get; set; }

    public required Guid SpecialtyId { get; set; }

    public virtual required SpecialtyEntity Specialty { get; set; }

    public virtual ICollection<User> Students { get; set; } = new List<User>();
}