namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class GroupGetResponseDto(GroupDto department)
{
    public GroupDto Group { get; set; } = department;
}