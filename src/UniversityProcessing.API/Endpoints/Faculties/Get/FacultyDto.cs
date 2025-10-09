namespace UniversityProcessing.API.Endpoints.Faculties.Get;

public sealed class FacultyDto(long id, string name, string shortName)
{
    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
}
