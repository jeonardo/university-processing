﻿using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.Entities
{
    public class EmployeeEntity : UserEntity, IAggregateRoot
    {
        public required Guid UniversityPositionId { get; set; }

        public required virtual UniversityPositionEntity UniversityPosition { get; set; }

        public required Guid EmployerId { get; set; }

        public required virtual UniversityEntity Employer { get; set; }

        public Guid? DepartmentId { get; set; }

        public virtual DepartmentEntity? Department { get; set; }
    }
}
