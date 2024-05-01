using UniversityProcessing.Domain;

namespace UniversityProcessing.DomainServices.Core;

public record AuthTokenClaims(Guid UserId, UserRoleId RoleIdId, string Email);