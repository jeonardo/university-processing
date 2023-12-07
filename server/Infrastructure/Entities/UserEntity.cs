using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UserEntity : IdentityUser<Guid>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //[Required]
        //[StringLength(50, MinimumLength = 2)]
        //public string Name { get; set; } = string.Empty;
        //public string Surname { get; set; } = string.Empty;
        //[Range(0, 5)]
        //public string Patronymic { get; set; } = string.Empty;
        //[Key]
        //[ForeignKey("Instructor")]
        //public int InstructorID { get; set; }
        //[StringLength(50)]
        //[Display(Name = "Office Location")]
        //public string Location { get; set; }
        //public virtual Instructor Instructor { get; set; }
        //public virtual ICollection<Course> Courses { get; set; }
        //public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
