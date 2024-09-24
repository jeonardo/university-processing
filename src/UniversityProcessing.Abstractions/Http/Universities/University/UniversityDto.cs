namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityDto(Guid id, string name, string shortName)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;

    public string ShortName { get; set; } = shortName;
}
