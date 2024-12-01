using System.ComponentModel.DataAnnotations;
using MediatR;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.ChangeAdmin;

public sealed class ChangeUniversityAdminRequestDto : IRequest
{
    [Required]
    public Guid UniversityId { get; init; }

    [Required]
    public Guid UserId { get; init; }
}
