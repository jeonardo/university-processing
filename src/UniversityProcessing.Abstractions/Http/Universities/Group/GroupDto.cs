namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GroupDto(Guid id, string number)
{
    public Guid Id { get; set; } = id;
    public string Number { get; set; } = number;
}
