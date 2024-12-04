using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Services.Auth;

public sealed record AuthTokenClaims(Guid UserId, UserRoleType RoleType, bool Approved);
