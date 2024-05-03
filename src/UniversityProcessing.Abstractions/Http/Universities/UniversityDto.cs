namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityDto
{
    public string Name { get; set; }

    public string ShortName { get; set; }

    public UniversityDto(string name, string shortName)
    {
        Name = name;
        ShortName = shortName;
    }
}