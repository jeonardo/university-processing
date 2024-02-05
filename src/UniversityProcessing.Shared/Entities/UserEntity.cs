using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Shared.Entities
{
    public class UserEntity : IdentityUser<Guid>, IBaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTimeUTC { get; set; }

        public virtual UserProfileEntity UserProfile { get; set; } = default!;

        public virtual ICollection<GraduateWorkEntity> GraduateWorks { get; set; } = new List<GraduateWorkEntity>();
    }
}
