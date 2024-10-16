using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Admin;

public sealed class UpdateIsApprovedStatusRequestDto
{
    [Required]
    [NotDefault]
    public Guid UserId { get; set; }

    [Required]
    public bool IsApproved { get; set; }
}
