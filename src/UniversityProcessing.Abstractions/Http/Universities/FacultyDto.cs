namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class FacultyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string ShortName { get; set; }

    public FacultyDto(Guid id, string name, string shortName)
    {
        Id = id;
        Name = name;
        ShortName = shortName;
    }
}