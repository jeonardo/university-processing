namespace UniversityProcessing.Domain.Entities
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
