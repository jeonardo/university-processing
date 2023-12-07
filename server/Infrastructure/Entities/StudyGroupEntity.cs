namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudyGroupEntity : BaseEntity
    {
        public required string GroupNumber { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }


    }
}
