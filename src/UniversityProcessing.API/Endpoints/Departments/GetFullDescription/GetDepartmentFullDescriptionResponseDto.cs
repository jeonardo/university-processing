namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

public sealed class GetDepartmentFullDescriptionResponseDto(
    Guid id,
    string name,
    string shortName,
    DepartmentFullDescriptionUserDto? head,
    IEnumerable<DepartmentFullDescriptionUserDto> teachers)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public DepartmentFullDescriptionUserDto? Head { get; set; } = head;
    public IEnumerable<DepartmentFullDescriptionUserDto> Teachers { get; set; } = teachers;
}
