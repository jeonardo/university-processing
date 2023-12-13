namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudentEntity : UserEntity
    {
        public required virtual StudyGroupEntity StudyGroup { get; set; }
    }
}
