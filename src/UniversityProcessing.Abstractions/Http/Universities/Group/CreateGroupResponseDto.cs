namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class CreateGroupResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
