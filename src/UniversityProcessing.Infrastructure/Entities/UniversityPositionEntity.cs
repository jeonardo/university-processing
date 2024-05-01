using UniversityProcessing.Infrastructure.Entities.Base;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class UniversityPositionEntity : BaseEntity, IBaseEntity, IAggregateRoot
{
    public required string Name { get; set; }

    public required Guid UniversityId { get; set; }

    public virtual required UniversityEntity University { get; set; }
}