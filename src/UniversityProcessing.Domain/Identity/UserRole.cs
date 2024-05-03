using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityProcessing.Domain.Identity;

public class UserRole : IdentityRole<Guid>
{
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }

    [MaxLength(100)]
    public string? DefaultPermissions { get; set; }
}