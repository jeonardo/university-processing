namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

public sealed class ResponseDto(
    long id,
    string name,
    string shortName,
    UserDto? head,
    IEnumerable<UserDto> teachers)
{
    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public UserDto? Head { get; set; } = head;
    public IEnumerable<UserDto> Teachers { get; set; } = teachers;
}
