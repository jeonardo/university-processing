using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Services.Registration.Forms;

public interface IRegistrationForm
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? Birthday { get; set; }
}
