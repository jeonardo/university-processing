using Microsoft.AspNetCore.Identity;
using UniversityProcessing.API.Interfaces.Entities;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class UserRoleEntity : IdentityRole<Guid>, IBaseEntity
    {
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
