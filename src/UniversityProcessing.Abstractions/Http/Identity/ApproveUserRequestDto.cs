using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Identity;

public sealed class ApproveUserRequestDto
{
    [Required]
    [NotDefault]
    public Guid UserId { get; set; }
}
