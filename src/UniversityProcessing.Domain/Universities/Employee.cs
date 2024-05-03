using Ardalis.SharedKernel;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.Universities;

public class Employee : User, IAggregateRoot
{
    public required Guid UniversityPositionId { get; set; }

    public virtual required UniversityPosition UniversityPosition { get; set; }

    public required Guid EmployerId { get; set; }

    public virtual required University Employer { get; set; }

    public Guid? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}