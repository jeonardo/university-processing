using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Contracts;

public sealed record AuthTokenClaims(Guid UserId, UserRoleType RoleType, bool Approved, bool Blocked);
