using System.Collections.Immutable;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API;

public static class Policies
{
    public const string CLAIMS_BASED_DEFAULT_ACCESS = nameof(CLAIMS_BASED_DEFAULT_ACCESS);

    public const string IDENTITY_DELETE_ACCESS = nameof(IDENTITY_DELETE_ACCESS);

    public static readonly ImmutableDictionary<string, string> PermissionsByPolicy = new Dictionary<string, string>
        {
            { CLAIMS_BASED_DEFAULT_ACCESS, nameof(UserPermissions.Default) },
            { IDENTITY_DELETE_ACCESS, nameof(UserPermissions.IdentityDeleteAccess) }
        }
        .ToImmutableDictionary();
}
