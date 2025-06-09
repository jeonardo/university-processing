using UniversityProcessing.API.TODO.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Auth.Info;

public sealed class InfoResponseDto(Guid userId, UserRoleTypeDto roleType, bool approved)
{
    public Guid UserId { get; set; } = userId;

    public UserRoleTypeDto RoleType { get; set; } = roleType;

    public bool Approved { get; set; } = approved;

} 
