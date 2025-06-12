using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Auth.Info;

public sealed class InfoResponseDto(Guid userId, UserRoleTypeDto[] roleTypes, bool approved, bool blocked, string firstName, string lastName, string? middleName)
{
    public Guid UserId { get; set; } = userId;

    public UserRoleTypeDto[] RoleTypes { get; set; } = roleTypes;

    public bool Approved { get; set; } = approved;

    public bool Blocked { get; set; } = blocked;

    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
}
