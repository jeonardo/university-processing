namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class GroupCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}