namespace UniversityProcessing.API.Endpoints.Specialties.Get;

public sealed class SpecialtyDto(long id, string name, string shortName, string code)
{
    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public string Code { get; set; } = code;
}
