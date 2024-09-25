using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityProcessing.Domain.Identity;

public sealed class UserRole : IdentityRole<Guid>
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string? DefaultPermissions { get; private set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private UserRole()
    {
    }

    public static UserRole Create(string roleName, string? defaultPermissions = null)
    {
        return new UserRole
        {
            Name = roleName,
            DefaultPermissions = defaultPermissions
        };
    }
}
