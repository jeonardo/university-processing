using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Shared.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
