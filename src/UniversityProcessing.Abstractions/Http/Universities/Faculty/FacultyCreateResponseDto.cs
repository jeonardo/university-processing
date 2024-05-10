namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class FacultyCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}