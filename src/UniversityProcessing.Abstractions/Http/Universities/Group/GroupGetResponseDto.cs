namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GroupGetResponseDto(GroupDto department)
{
    public GroupDto Group { get; set; } = department;
}