namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableFaculties;

public sealed class FacultyDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}
