namespace UniversityProcessing.API.Endpoints.Departments.Get;

public sealed class DepartmentDto(Guid id, string name, string shortName)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
}
