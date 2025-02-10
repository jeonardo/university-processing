namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class SpecialtyDto(Guid id, string name, string shortName, string code, GroupDto[] groups)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public string Code { get; set; } = code;
    public GroupDto[] Groups { get; set; } = groups;
}
