namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityPositionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public UniversityPositionDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}