namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class FacultyDto(Guid id, string name, string shortName, DepartmentDto[] departments, UserDto leader, UserDto[] members)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public DepartmentDto[] Departments { get; set; } = departments;
    public UserDto Leader { get; set; } = leader;
    public UserDto[] Members { get; set; } = members;
}
