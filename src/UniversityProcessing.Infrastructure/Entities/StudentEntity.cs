using UniversityProcessing.Domain;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class StudentEntity : User, IAggregateRoot
{
    public virtual required StudyGroupEntity StudyGroup { get; set; }

    public virtual ICollection<GraduateWorkEntity> GraduateWorks { get; set; } = [];
}