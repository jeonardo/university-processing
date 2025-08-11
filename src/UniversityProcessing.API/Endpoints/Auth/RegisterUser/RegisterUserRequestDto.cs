using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Services.Registration.Forms;

namespace UniversityProcessing.API.Endpoints.Auth.RegisterUser;

public sealed class RegisterUserRequestDto
    : IAdminRegistrationForm,
        IDeaneryRegistrationForm,
        ITeacherRegistrationForm,
        IStudentRegistrationForm
{
    [Required]
    public UserRoleDto Role { get; set; }

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

    public Guid FacultyId { get; set; }

    public string GroupNumber { get; set; } = string.Empty;

    public Guid UniversityPositionId { get; set; }

    public Guid DepartmentId { get; set; }
}
