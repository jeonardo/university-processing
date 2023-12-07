namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class FacultyEntity : BaseEntity
    {
        public required string Name { get; set; }

        public required string ShortName { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }

        public required virtual ICollection<DepartmentEntity> Departments { get; set; }
    }
}