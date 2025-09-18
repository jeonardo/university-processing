namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableDepartments;

public sealed class DepartmentDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}
