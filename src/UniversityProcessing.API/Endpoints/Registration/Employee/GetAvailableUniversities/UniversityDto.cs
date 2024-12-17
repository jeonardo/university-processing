namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversities;

public sealed class UniversityDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}
