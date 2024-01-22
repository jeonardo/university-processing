using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Domain.Entities
{
    public class UserRoleEntity : IdentityRole<Guid>, IBaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
