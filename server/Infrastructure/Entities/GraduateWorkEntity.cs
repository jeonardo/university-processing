namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class GraduateWorkEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int Grade { get; set; }

        public StatusEntity? Status { get; set; }

        public UserEntity? Student { get; set; }

        public UserEntity? Supervisor { get; set; }
    }
}
