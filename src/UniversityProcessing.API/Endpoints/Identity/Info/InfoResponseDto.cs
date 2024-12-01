using System.Text.Json.Serialization;
using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class InfoResponseDto(Guid userId, UserRoleIdDto roleId, bool approved)
{
    public Guid UserId { get; set; } = userId;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRoleIdDto RoleId { get; set; } = roleId;

    public bool Approved { get; set; } = approved;
}
