using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Infrastructure.Entities.Base;

public class BaseEntity : IBaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}