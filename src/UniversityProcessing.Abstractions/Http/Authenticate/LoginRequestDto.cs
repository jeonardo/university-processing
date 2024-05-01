using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Authenticate;

public sealed class LoginRequestDto
{
    [Required]
    [MinLength(1)]
    public required string UserName { get; set; }

    [Required]
    [MinLength(4)]
    public required string Password { get; set; }
}