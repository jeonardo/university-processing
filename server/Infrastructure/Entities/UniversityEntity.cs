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

        public required virtual ICollection<FacultyEntity> Faculties { get; set; }

        public required virtual ICollection<DepartmentEntity> Departments { get; set; }

        public required virtual ICollection<SpecialtyEntity> Specialties { get; set; }

        public required virtual ICollection<StudyGroupEntity> StudyGroups { get; set; }

        public required virtual ICollection<StudentEntity> Students { get; set; }

        public required virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}