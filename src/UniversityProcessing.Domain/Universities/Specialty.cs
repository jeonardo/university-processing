using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class Specialty : EntityBase, IAggregateRoot
{
    [StringLength(50, MinimumLength = 1)]
    public required string Name { get; set; }

    [StringLength(25, MinimumLength = 1)]
    public required string ShortName { get; set; }

    [StringLength(12, MinimumLength = 12)]
    public required string Code { get; set; }

    public required Guid FacultyId { get; set; }

    public virtual required Faculty Faculty { get; set; }

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}