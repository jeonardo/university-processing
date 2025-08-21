using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Utils.Identity;

public abstract class BaseEntity : EntityBase<Guid>, IAggregateRoot, IHasId
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
