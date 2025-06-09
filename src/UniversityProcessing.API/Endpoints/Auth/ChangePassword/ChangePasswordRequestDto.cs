using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.ChangePassword;

public sealed class ChangePasswordRequestDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string NewPassword { get; set; } = string.Empty;
}
