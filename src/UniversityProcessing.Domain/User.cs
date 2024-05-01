using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityProcessing.Domain;

public class User : IdentityUser<Guid>
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [MaxLength(100)]
    public string? MiddleName { get; set; }
}