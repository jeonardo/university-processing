using Ardalis.SharedKernel;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.Universities;

public class Student : User, IAggregateRoot
{
    public virtual required StudyGroup StudyGroup { get; set; }

    public virtual ICollection<GraduateWork> GraduateWorks { get; set; } = [];
}