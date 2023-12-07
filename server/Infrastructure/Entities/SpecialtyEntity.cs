using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class SpecialtyEntity : BaseEntity
    {
        public required string Name { get; set; }

        public required string ShortName { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }

        public required Guid FacultyId { get; set; }

        public required virtual FacultyEntity Faculty { get; set; }

        public required Guid DepartmentId { get; set; }

        public required virtual DepartmentEntity Department { get; set; }
    }
}
