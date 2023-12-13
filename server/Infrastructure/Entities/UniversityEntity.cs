using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UniversityEntity : BaseEntity, IBaseEntity
    {
        [StringLength(25, MinimumLength = 1)]
        public required string Name { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public required string ShortName { get; set; }

        public virtual ICollection<FacultyEntity> Faculties { get; set; } = new List<FacultyEntity>();

        public virtual ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();

        public virtual ICollection<SpecialtyEntity> Specialties { get; set; } = new List<SpecialtyEntity>();

        public virtual ICollection<StudyGroupEntity> StudyGroups { get; set; } = new List<StudyGroupEntity>();

        public virtual ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();

        public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}