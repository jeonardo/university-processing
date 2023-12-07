using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudentEntity
    {
        //public int ID { get; set; } // Primary key

        //[Required]
        //[StringLength(50)]
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        //[Required]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //[Column("FirstName")]
        //[Display(Name = "First Name")]
        //public string FirstMidName { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Enrollment Date")]
        //public DateTime EnrollmentDate { get; set; }

        //[Display(Name = "Full Name")]
        //public string FullName
        //{
        //    get
        //    {
        //        return LastName + ", " + FirstMidName;
        //    }
        //}

        //// Navigation property
        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
