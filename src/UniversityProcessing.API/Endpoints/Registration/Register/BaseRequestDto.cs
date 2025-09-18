using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.Register;

public abstract class BaseRequestDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? Birthday { get; set; }
}
