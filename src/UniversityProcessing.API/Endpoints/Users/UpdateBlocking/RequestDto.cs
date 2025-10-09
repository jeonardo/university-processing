using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Users.UpdateBlocking;

public sealed class RequestDto
{
    [Required]
    public long UserId { get; set; }

    [Required]
    public bool IsBlocked { get; set; }
}
