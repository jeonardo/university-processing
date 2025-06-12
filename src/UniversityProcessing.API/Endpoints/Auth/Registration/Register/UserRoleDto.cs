using System.Text.Json.Serialization;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoleDto
{
    None = 0,
    Deanery = 2,
    Teacher = 3,
    Student = 4
}
