namespace UniversityProcessing.API.Endpoints.Employee.GetGroups;

public sealed class GroupDto(Guid id, string number)
{
    public Guid Id { get; set; } = id;
    public string Number { get; set; } = number;
}
