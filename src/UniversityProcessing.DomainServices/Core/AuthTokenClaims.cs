using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.DomainServices.Core;

public sealed record AuthTokenClaims(Guid UserId, UserRoles Roles, bool Approved);
