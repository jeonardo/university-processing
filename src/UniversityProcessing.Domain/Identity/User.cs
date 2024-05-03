using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityProcessing.Domain.Identity;

public class User : IdentityUser<Guid>
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string FirstName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? LastName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? MiddleName { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; set; }
}