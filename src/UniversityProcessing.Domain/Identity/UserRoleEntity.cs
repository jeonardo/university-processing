using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Entities;

namespace UniversityProcessing.Domain.Identity
{
    public class UserRoleEntity : IdentityRole<Guid>, IBaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
