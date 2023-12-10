using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudyGroupEntity : BaseEntity
    {
        public required string GroupNumber { get; set; }

        [DataType(DataType.Date)]
        public required DateOnly StartDate { get; set; }

        [DataType(DataType.Date)]
        public required DateOnly EndDate { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }

        public required Guid FacultyId { get; set; }

        public required virtual FacultyEntity Faculty { get; set; }

        public required Guid DepartmentId { get; set; }

        public required virtual DepartmentEntity Department { get; set; }

        public required virtual ICollection<UserEntity> Students { get; set; }
    }
}
