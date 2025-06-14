namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Get;

public sealed class DiplomaPeriodUserDto(Guid id, string firstName, string lastName, string? middleName, string? universityPosition, bool added)
{
    public Guid Id { get; set; } = id;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public string? MiddleName { get; set; } = middleName;

    public string? UniversityPosition { get; set; } = universityPosition;

    public bool Added { get; set; } = added;
}
