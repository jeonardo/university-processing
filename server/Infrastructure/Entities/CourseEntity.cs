using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class CourseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
