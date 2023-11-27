namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class FacultyEntity : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public UniversityEntity? University { get; set; }
    }
}