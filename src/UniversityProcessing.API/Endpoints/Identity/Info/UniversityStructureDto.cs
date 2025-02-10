namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class UniversityStructureDto(string name, string shortName, FacultyDto[] faculties)
{
    public string Name { get; set; } = name;
    public string ShortName { get; set; } = shortName;
    public FacultyDto[] Faculties { get; set; } = faculties;
}
