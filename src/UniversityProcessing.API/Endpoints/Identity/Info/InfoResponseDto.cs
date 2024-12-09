using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class InfoResponseDto(Guid userId, UserRoleDto role, bool approved)
{
    public Guid UserId { get; set; } = userId;

    public UserRoleDto Role { get; set; } = role;

    public bool Approved { get; set; } = approved;
}
