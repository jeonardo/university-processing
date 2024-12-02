using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Groups.Create;

public sealed class CreateGroupRequestDto
{
    [Required]
    public string GroupNumber { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public Guid? SpecialtyId { get; set; }
}
