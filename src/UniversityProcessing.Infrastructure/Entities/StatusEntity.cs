using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Infrastructure.Entities.Base;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class StatusEntity : BaseEntity, IAggregateRoot
{
    [StringLength(10, MinimumLength = 1)]
    public required string Name { get; set; }
}