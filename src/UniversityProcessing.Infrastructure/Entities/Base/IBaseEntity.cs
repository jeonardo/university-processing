namespace UniversityProcessing.Infrastructure.Entities.Base;

public interface IBaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
}