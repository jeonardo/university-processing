namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class UserDto(
    Guid id,
    string firstName,
    string? lastName,
    string? middleName,
    string? email,
    DateTime? birthday)
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
    public string? Email { get; set; } = email;
    public DateTime? Birthday { get; set; } = birthday;
}
