namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class DepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string ShortName { get; set; }

    public DepartmentDto(Guid id, string name, string shortName)
    {
        Id = id;
        Name = name;
        ShortName = shortName;
    }
}