using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.DomainServices.Core;

public sealed record AuthTokenClaims(Guid UserId, UserRoleId RoleId, bool Approved);