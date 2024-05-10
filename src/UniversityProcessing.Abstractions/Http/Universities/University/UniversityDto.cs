namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string ShortName { get; set; }

    public UniversityDto(Guid id, string name, string shortName)
    {
        Id = id;
        Name = name;
        ShortName = shortName;
    }
}