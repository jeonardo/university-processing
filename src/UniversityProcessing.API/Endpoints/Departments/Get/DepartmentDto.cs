namespace UniversityProcessing.API.Endpoints.Departments.Get;

public sealed class DepartmentDto(long id, string name, string shortName)
{
    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
}
