using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class UniversityPosition : EntityBase, IAggregateRoot
{
    public required string Name { get; set; }

    public required Guid UniversityId { get; set; }

    public virtual required University University { get; set; }
}