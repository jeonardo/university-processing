namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

public sealed class ResponseDto(
    Guid id,
    string name,
    string shortName,
    UserDto? head,
    IEnumerable<UserDto> teachers)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public UserDto? Head { get; set; } = head;
    public IEnumerable<UserDto> Teachers { get; set; } = teachers;
}
