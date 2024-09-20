using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Bases;

public abstract class BaseEntity : EntityBase<Guid>, IAggregateRoot
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
