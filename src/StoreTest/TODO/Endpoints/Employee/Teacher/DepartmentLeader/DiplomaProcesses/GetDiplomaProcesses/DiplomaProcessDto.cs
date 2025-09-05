namespace StoreTest.TODO.Endpoints.Employee.GetDiplomaProcesses;

public sealed class DiplomaProcessDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}
