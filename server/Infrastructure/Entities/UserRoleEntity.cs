using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UserRoleEntity : IdentityRole<Guid>, IBaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
