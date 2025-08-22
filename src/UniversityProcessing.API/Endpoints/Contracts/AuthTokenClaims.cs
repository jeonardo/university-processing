using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Contracts;

public sealed record AuthTokenClaims(Guid UserId, IReadOnlySet<UserRoleType> Roles, bool Approved, bool Blocked);
