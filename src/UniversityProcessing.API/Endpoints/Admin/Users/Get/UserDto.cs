namespace UniversityProcessing.API.Endpoints.Admin.Users.Get;

public sealed record UserDto(Guid Id, string FirstName, string LastName, string? MiddleName, bool Approved);
