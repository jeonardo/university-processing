using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UniversityProcessing.Domain.Entities
{
    public class GraduateWorkEntity : BaseEntity
    {
        [StringLength(50, MinimumLength = 1)]
        public required string Title { get; set; }

        [AllowNull]
        [Range(0, 10)]
        public int? Grade { get; set; }

        public required Guid StatusId { get; set; }

        public required StatusEntity Status { get; set; }

        public required Guid StudentId { get; set; }

        public required StudentEntity Student { get; set; }

        public required Guid SupervisorId { get; set; }

        public required EmployeeEntity Supervisor { get; set; }
    }
}
