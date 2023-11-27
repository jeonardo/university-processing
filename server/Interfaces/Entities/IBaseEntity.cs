namespace UniversityProcessing.API.Interfaces.Entities
{
    public interface IBaseEntity
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
