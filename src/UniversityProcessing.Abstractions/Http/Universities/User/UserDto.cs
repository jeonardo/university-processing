namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Email { get; set; }
    public DateOnly? Birthday { get; set; }

    public UserDto(
        Guid id,
        string firstName,
        string? lastName,
        string? middleName,
        string? email,
        DateOnly? birthday)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Birthday = birthday;
    }
}
