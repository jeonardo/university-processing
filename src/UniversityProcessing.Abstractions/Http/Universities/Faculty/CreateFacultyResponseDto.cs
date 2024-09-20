namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class CreateFacultyResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
