using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Domain.Entities
{
    public class StudyGroupEntity : BaseEntity
    {
        public required string GroupNumber { get; set; }

        [DataType(DataType.Date)]
        public required DateOnly StartDate { get; set; }

        [DataType(DataType.Date)]
        public required DateOnly EndDate { get; set; }

        public required Guid SpecialtyId { get; set; }

        public required virtual SpecialtyEntity Specialty { get; set; }

        public virtual ICollection<UserEntity> Students { get; set; } = new List<UserEntity>();
    }
}
