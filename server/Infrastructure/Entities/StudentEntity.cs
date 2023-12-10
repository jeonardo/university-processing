namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudentEntity : UserEntity
    {
        public required virtual ICollection<StudyGroupEntity> StudyGroups { get; set; }
    }
}
