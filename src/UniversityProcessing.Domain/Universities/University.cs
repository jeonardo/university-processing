using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class University(string name, string shortName) : EntityBase, IAggregateRoot
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = Guard.Against.NullOrEmpty(shortName, nameof(shortName));

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}