﻿namespace UniversityProcessing.Domain.Entities
{
    public class UniversityPositionEntity : BaseEntity, IBaseEntity
    {
        public required string Name { get; set; }

        public required Guid UniversityId { get; set; }

        public required virtual UniversityEntity University { get; set; }
    }
}
