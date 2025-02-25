using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class InfoResponseDto(Guid userId, UserRoleTypeDto roleType, bool approved, UniversityStructureDto? universityStructure = null) //TODO how to use
{
    public Guid UserId { get; set; } = userId;

    public UserRoleTypeDto RoleType { get; set; } = roleType;

    public bool Approved { get; set; } = approved;

    public UniversityStructureDto? UniversityStructure { get; set; } = universityStructure;
} //Get infrstructructure where I am
