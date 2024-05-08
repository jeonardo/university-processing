namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class SpecialtyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Code { get; set; }

    public SpecialtyDto(Guid id, string name, string shortName, string code)
    {
        Id = id;
        Name = name;
        ShortName = shortName;
        Code = code;
    }
}