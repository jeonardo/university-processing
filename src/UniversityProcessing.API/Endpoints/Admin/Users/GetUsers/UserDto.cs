namespace UniversityProcessing.API.Endpoints.Admin.Users.GetUsers;

public sealed record UserDto(Guid Id, string FirstName, string LastName, string? MiddleName, bool Approved);
