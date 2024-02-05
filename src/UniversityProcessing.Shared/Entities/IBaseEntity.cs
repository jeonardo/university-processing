namespace UniversityProcessing.Shared.Entities
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
