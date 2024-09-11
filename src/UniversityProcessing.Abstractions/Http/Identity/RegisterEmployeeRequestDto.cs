using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Identity;

public sealed class RegisterEmployeeRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string UserName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 4)]
    public required string Password { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string LastName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? MiddleName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; set; }

    public Guid? UniversityId { get; set; }

    public Guid? UniversityPositionId { get; set; }
}
