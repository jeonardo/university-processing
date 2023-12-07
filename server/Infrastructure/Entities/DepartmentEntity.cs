namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class DepartmentEntity : BaseEntity
    {
        public required string Name { get; set; }

        public required string ShortName { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }

        public required Guid FacultyId { get; set; }

        public required virtual FacultyEntity Faculty { get; set; }

        public required virtual ICollection<SpecialtyEntity> Specialties { get; set; }
    }
}
