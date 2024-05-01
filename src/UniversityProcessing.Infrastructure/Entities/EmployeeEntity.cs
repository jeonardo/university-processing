using UniversityProcessing.Domain;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class EmployeeEntity : User, IAggregateRoot
{
    public required Guid UniversityPositionId { get; set; }

    public virtual required UniversityPositionEntity UniversityPosition { get; set; }

    public required Guid EmployerId { get; set; }

    public virtual required UniversityEntity Employer { get; set; }

    public Guid? DepartmentId { get; set; }

    public virtual DepartmentEntity? Department { get; set; }
}