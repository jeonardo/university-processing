namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class CreateUniversityResponseDto
{
    public Guid Id { get; set; }

    public CreateUniversityResponseDto(Guid id)
    {
        Id = id;
    }
}
