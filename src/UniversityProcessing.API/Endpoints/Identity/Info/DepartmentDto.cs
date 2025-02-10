namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class DepartmentDto(Guid id, string name, string shortName, SpecialtyDto[] specialties, UserDto leader)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public SpecialtyDto[] Specialties { get; set; } = specialties;
    public UserDto Leader { get; set; } = leader;
}
