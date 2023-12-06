namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudentEntity
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
