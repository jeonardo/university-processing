using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class InfoResponseDto(Guid userId, UserRoleTypeDto roleType, bool approved)
{
    public Guid UserId { get; set; } = userId;

    public UserRoleTypeDto RoleType { get; set; } = roleType;

    public bool Approved { get; set; } = approved;
}
