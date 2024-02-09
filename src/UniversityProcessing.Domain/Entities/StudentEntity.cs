﻿using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.Entities
{
    public class StudentEntity : UserEntity
    {
        public required virtual StudyGroupEntity StudyGroup { get; set; }

        public virtual ICollection<GraduateWorkEntity> GraduateWorks { get; set; } = [];
    }
}
