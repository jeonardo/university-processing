namespace UniversityProcessing.API.Endpoints.Admin.Faculties.Get;

public sealed class FacultyDto(Guid id, string name, string shortName)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;

    public string ShortName { get; set; } = shortName;
}
