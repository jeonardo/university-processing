namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

public sealed class FacultyFullDescriptionUserDto(
    Guid id,
    string firstName,
    string lastName,
    string? middleName,
    string? email,
    string? phoneNumber,
    string position,
    bool blocked,
    bool approved)
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
    public string? Email { get; set; } = email;
    public string? PhoneNumber { get; set; } = phoneNumber;
    public string Position { get; set; } = position;
    public bool Blocked { get; private set; } = blocked;
    public bool Approved { get; private set; } = approved;
}
