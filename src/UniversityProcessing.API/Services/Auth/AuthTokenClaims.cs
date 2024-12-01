using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Services.Auth;

public sealed record AuthTokenClaims(Guid UserId, UserRoles Roles, bool Approved);
