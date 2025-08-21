namespace StoreTest.Admin.GetUsers;

public sealed class UserDto(Guid id, string firstName, string lastName, string? middleName, bool approved)
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
    public bool Approved { get; set; } = approved;
}
