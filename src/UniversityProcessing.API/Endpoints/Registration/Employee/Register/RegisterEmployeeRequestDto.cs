using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.Employee.Register;

public sealed class RegisterEmployeeRequestDto
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

    public DateTime? Birthday { get; set; }

    public Guid? UniversityId { get; set; }

    public Guid? UniversityPositionId { get; set; }
}
