﻿namespace UniversityProcessing.Shared.Entities
{
    public class StudentEntity : UserEntity
    {
        public required virtual StudyGroupEntity StudyGroup { get; set; }
    }
}