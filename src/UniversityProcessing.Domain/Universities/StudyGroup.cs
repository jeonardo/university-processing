using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.Universities;

public class StudyGroup : EntityBase, IAggregateRoot
{
    public required string GroupNumber { get; set; }

    [DataType(DataType.Date)]
    public required DateOnly StartDate { get; set; }

    [DataType(DataType.Date)]
    public required DateOnly EndDate { get; set; }

    public required Guid SpecialtyId { get; set; }

    public virtual required Specialty Specialty { get; set; }

    public virtual ICollection<User> Students { get; set; } = new List<User>();
}