namespace UniversityProcessing.API.Endpoints.Users.GetTeachers;

public sealed class TeacherDto(Guid id, string firstName, string lastName, string? middleName, bool approved, bool blocked, string position)
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
    public bool Approved { get; set; } = approved;
    public bool Blocked { get; set; } = blocked;
    public string Position { get; set; } = position;
}
