namespace UniversityProcessing.API.TODO.Endpoints.Employee.GetSpecialties;

public sealed class SpecialtyDto(Guid id, string name, string shortName, string code)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public string Code { get; set; } = code;
}
