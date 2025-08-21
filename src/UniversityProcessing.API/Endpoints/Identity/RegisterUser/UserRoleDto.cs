using System.Text.Json.Serialization;

namespace UniversityProcessing.API.Endpoints.Identity.RegisterUser;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoleDto
{
    None = 0,
    Admin = 1,
    Deanery = 2,
    Teacher = 3,
    Student = 4
}
