namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Get;

public sealed class EmployeeDto(Guid id, string firstName, string lastName, string? middleName, string? universityPosition, bool added)
{
    public Guid Id { get; set; } = id;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public string? MiddleName { get; set; } = middleName;

    public string? UniversityPosition { get; set; } = universityPosition;

    public bool Added { get; set; } = added;
}
