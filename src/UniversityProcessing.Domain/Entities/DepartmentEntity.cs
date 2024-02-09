using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Domain.Entities
{
    public class DepartmentEntity : BaseEntity
    {
        [StringLength(25, MinimumLength = 1)]
        public required string Name { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public required string ShortName { get; set; }

        public required Guid FacultyId { get; set; }

        public required virtual FacultyEntity Faculty { get; set; }

        public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
