using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class DepartmentEntity : BaseEntity
    {
        [StringLength(25, MinimumLength = 1)]
        public required string Name { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public required string ShortName { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }

        public required Guid FacultyId { get; set; }

        public required virtual FacultyEntity Faculty { get; set; }

        public required Guid SupervisorId { get; set; }

        public required virtual EmployeeEntity Supervisor { get; set; }

        public required virtual ICollection<SpecialtyEntity> Specialties { get; set; }

        public required virtual ICollection<StudentEntity> Students { get; set; }

        public required virtual ICollection<EmployeeEntity> Employees { get; set; }

        public required virtual ICollection<StudyGroupEntity> StudyGroups { get; set; }

    }
}
