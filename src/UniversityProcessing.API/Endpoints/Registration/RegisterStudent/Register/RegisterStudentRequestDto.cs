using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterStudent.Register;

public sealed class RegisterStudentRequestDto
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

    public string? GroupNumber { get; set; }
}
