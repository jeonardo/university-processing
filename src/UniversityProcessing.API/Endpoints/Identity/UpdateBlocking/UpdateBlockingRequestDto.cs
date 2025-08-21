using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Identity.UpdateBlocking;

public sealed class UpdateBlockingRequestDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public bool IsBlocked { get; set; }
}
