using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Shared.Entities
{
    public class FacultyEntity : BaseEntity
    {
        [StringLength(25, MinimumLength = 1)]
        public required string Name { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public required string ShortName { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }

        public virtual ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();

        public virtual ICollection<SpecialtyEntity> Specialties { get; set; } = new List<SpecialtyEntity>();

        public virtual ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();

        public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();

        public virtual ICollection<StudyGroupEntity> StudyGroups { get; set; } = new List<StudyGroupEntity>();
    }
}