namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GetGroupResponseDto(GroupDto department)
{
    public GroupDto Group { get; set; } = department;
}
