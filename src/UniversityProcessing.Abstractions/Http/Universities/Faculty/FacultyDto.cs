namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class FacultyDto(Guid id, string name, string shortName)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;

    public string ShortName { get; set; } = shortName;
}
