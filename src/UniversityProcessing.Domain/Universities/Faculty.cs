using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class Faculty : EntityBase, IAggregateRoot
{
    [StringLength(50, MinimumLength = 1)]
    public required string Name { get; set; }

    [StringLength(25, MinimumLength = 1)]
    public required string ShortName { get; set; }

    public required Guid UniversityId { get; set; }

    public virtual required University University { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
}