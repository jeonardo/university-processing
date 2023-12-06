using Microsoft.AspNetCore.Identity;
using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UserEntity : IdentityUser, IBaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Patronymic { get; set; } = string.Empty;
    }
}
