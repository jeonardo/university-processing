using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.GenericSubdomain.Guards;

namespace UniversityProcessing.Domain.Identity;

public sealed class UserRole : IdentityRole<Guid>
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string? DefaultPermissions { get; private set; }

    public UserRole(string roleName, string? defaultPermissions = null) : base(roleName)
    {
        DefaultPermissions = Guard.Against.NotNullAndWhiteSpace(defaultPermissions);
    }

    //Parameterless constructor used by EF Core
    private UserRole()
    {
    }
}