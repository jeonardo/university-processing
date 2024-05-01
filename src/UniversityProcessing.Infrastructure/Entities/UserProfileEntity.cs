using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Infrastructure.Entities.Base;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class UserProfileEntity : BaseEntity, IAggregateRoot
{
    [StringLength(25, MinimumLength = 1)]
    public required string FirstName { get; set; }

    [StringLength(25, MinimumLength = 1)]
    public required string LastName { get; set; }

    [StringLength(25, MinimumLength = 1)]
    public required string FatherName { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; set; }
}