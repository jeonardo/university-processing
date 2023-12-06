using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UniversityEntity : IBaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}