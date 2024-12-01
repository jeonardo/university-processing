using System.Text.Json.Serialization;

namespace UniversityProcessing.API.Endpoints.Contracts;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoleIdDto
{
    None = 0,
    ApplicationAdmin = 1,
    Employee = 2,
    Student = 3
}
