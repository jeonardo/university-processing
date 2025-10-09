using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Contracts;

public sealed record AuthTokenClaims(long UserId, UserRoleType Role, bool Approved, bool Blocked);
