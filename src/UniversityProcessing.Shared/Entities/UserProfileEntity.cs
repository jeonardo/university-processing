using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Shared.Entities
{
    public class UserProfileEntity : BaseEntity
    {
        [StringLength(25, MinimumLength = 1)]
        public required string FirstName { get; set; }

        [StringLength(25, MinimumLength = 1)]
        public required string LastName { get; set; }

        [StringLength(25, MinimumLength = 1)]
        public required string FatherName { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? Birthday { get; set; }
    }
}
