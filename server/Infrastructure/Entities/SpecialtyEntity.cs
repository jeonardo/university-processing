using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class SpecialtyEntity : BaseEntity
    {
        [StringLength(25, MinimumLength = 1)]
        public required string Name { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public required string ShortName { get; set; }

        [StringLength(12, MinimumLength = 12)]
        public required string Code { get; set; }

        public required Guid FacultyId { get; set; }

        public required virtual FacultyEntity Faculty { get; set; }

        public virtual ICollection<StudyGroupEntity> StudyGroups { get; set; } = new List<StudyGroupEntity>();

        public virtual ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();
    }
}
