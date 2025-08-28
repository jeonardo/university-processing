namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

public sealed class GetFacultyFullDescriptionResponseDto(
    Guid id,
    string name,
    string shortName,
    FacultyFullDescriptionUserDto? head,
    IEnumerable<FacultyFullDescriptionUserDto> deaneries)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public FacultyFullDescriptionUserDto? Head { get; set; } = head;
    public IEnumerable<FacultyFullDescriptionUserDto> Deaneries { get; set; } = deaneries;
}
