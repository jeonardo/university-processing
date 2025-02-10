using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class UserRole : IdentityRole<Guid>
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
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
