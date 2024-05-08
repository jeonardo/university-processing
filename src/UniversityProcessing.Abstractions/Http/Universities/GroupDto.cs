namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class GroupDto
{
    public Guid Id { get; set; }
    public string Number { get; set; }

    public GroupDto(Guid id, string number)
    {
        Id = id;
        Number = number;
    }
}