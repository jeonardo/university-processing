namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class CreateUniversityResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
