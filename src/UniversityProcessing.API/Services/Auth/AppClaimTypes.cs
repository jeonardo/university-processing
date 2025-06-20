using System.Security.Claims;

namespace UniversityProcessing.API.Services.Auth;

public static class AppClaimTypes
{
    public const string BOOL_TRUE = "true";
    public const string BOOL_FALSE = "false";

    public const string USER_ID = ClaimTypes.NameIdentifier;
    public const string ROLE = ClaimTypes.Role;
    public const string IS_APPROVED = "IsApproved";
    public const string IS_BLOCKED = "IsBlocked";
}
