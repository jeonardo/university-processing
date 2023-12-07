using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class GraduateWorkEntity1 : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; } // Primary key

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Grade { get; set; }

        public StatusEntity? Status { get; set; }

        public UserEntity? Student { get; set; }

        public UserEntity? Supervisor { get; set; }
    }
}
