using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class Department : EntityBase, IAggregateRoot
{
    [StringLength(50, MinimumLength = 1)]
    public required string Name { get; set; }

    [StringLength(25, MinimumLength = 1)]
    public required string ShortName { get; set; }

    public required Guid FacultyId { get; set; }

    public virtual required Faculty Faculty { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}