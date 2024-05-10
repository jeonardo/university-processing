namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GroupCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}