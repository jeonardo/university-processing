namespace UniversityProcessing.API.Endpoints.Users.GetAdmins;

public sealed class AdminDto(Guid id, string firstName, string lastName, string? middleName, bool approved, bool blocked)
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
    public bool Approved { get; set; } = approved;
    public bool Blocked { get; set; } = blocked;
}
