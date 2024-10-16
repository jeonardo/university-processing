using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class CreateGroupRequestDto
{
    [Required]
    [StringLength(25, MinimumLength = 1)]
    public string GroupNumber { get; set; } = string.Empty;

    [NotDefault]
    public DateOnly StartDate { get; set; }

    [NotDefault]
    public DateOnly EndDate { get; set; }

    [NotDefault]
    public Guid SpecialtyId { get; set; }
}
