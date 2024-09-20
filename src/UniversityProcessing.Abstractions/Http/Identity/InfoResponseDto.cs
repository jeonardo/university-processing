using System.Text.Json.Serialization;

namespace UniversityProcessing.Abstractions.Http.Identity;

public sealed class InfoResponseDto(Guid userId, UserRoleIdDto roleId, bool approved)
{
    public Guid UserId { get; init; } = userId;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRoleIdDto RoleId { get; init; } = roleId;

    public bool Approved { get; init; } = approved;
}
