namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class DepartmentEntity : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public FacultyEntity? Faculty { get; set; }
    }
}
