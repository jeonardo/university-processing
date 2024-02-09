namespace UniversityProcessing.Domain.Entities
{
    public class DiplomaProcessingEntity : BaseEntity
    {
        public required Guid SecretaryId { get; set; }

        public required ICollection<string> RequiredTitles { get; set; }

        public required virtual ICollection<GraduateWorkEntity> GraduateWorks { get; set; }

        public required virtual ICollection<StudentEntity> Students { get; set; }

        public required virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}
