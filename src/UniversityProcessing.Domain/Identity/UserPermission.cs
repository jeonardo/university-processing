using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.Domain.Identity;

public sealed class UserPermission
{
    public Guid UserId { get; set; }
    public UserPermissionId Id { get; set; }
    public bool Active { get; set; }
}