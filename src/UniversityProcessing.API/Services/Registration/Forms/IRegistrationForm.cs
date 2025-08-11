using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Services.Registration.Forms;

public interface IRegistrationForm
{
    [Required]
    string UserName { get; set; }

    [Required]
    string Password { get; set; }

    [Required]
    string FirstName { get; set; }

    [Required]
    string LastName { get; set; }

    string? MiddleName { get; set; }

    string? Email { get; set; }

    string? PhoneNumber { get; set; }

    DateTime? Birthday { get; set; }
}
