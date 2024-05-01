using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Infrastructure.Entities.Base;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class DepartmentEntity : BaseEntity, IAggregateRoot
{
    [StringLength(25, MinimumLength = 1)]
    public required string Name { get; set; }

    [StringLength(10, MinimumLength = 1)]
    public required string ShortName { get; set; }

    public required Guid FacultyId { get; set; }

    public virtual required FacultyEntity Faculty { get; set; }

    public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
}