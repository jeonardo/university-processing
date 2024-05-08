namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class FacultyCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}