namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableFaculties;

public sealed class FacultyDto(long id, string name)
{
    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
}
