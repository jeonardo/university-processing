using System.Text.Json.Serialization;

namespace UniversityProcessing.API.Endpoints.Contracts;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoleTypeDto
{
    None = 0,
    Admin = 1,
    Deanery = 2,
    Teacher = 3,
    Student = 4
}
