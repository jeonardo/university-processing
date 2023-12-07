using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UniversityEntity : BaseEntity, IBaseEntity
    {
        public required string Name { get; set; }

        public required string ShortName { get; set; }

        public required virtual ICollection<FacultyEntity> Faculties { get; set; }
    }
}