using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Entities;

namespace UniversityProcessing.Domain.Identity
{
    public class UserEntity : IdentityUser<Guid>, IBaseEntity, IAggregateRoot
    {
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTimeUTC { get; set; }

        public virtual UserProfileEntity UserProfile { get; set; } = default!;
    }
}
