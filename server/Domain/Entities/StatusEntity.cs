using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Domain.Entities
{
    public class StatusEntity : BaseEntity
    {
        [StringLength(10, MinimumLength = 1)]
        public required string Name { get; set; }
    }
}