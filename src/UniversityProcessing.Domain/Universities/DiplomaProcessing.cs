using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class DiplomaProcessing : EntityBase, IAggregateRoot
{
    public required Guid SecretaryId { get; set; }

    public required ICollection<string> RequiredTitles { get; set; }

    public virtual required ICollection<GraduateWork> GraduateWorks { get; set; }

    public virtual required ICollection<Student> Students { get; set; }

    public virtual required ICollection<Employee> Employees { get; set; }
}