namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GetGroupResponseDto(GroupDto group)
{
    public GroupDto Group { get; set; } = group;
}
