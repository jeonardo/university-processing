namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityPositionDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}
