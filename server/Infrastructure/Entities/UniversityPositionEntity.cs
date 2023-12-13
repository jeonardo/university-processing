using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UniversityPositionEntity : BaseEntity, IBaseEntity
    {
        public required string Name { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }
    }
}
