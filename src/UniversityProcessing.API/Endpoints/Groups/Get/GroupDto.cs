namespace UniversityProcessing.API.Endpoints.Groups.Get;

public sealed class GroupDto(long id, string number)
{
    public long Id { get; set; } = id;
    public string Number { get; set; } = number;
}
