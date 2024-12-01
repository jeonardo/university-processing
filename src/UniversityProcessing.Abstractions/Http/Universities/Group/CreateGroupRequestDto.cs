using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class CreateGroupRequestDto
{
    [Required]
    [StringLength(25, MinimumLength = 1)]
    public string GroupNumber { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid SpecialtyId { get; set; }
}
