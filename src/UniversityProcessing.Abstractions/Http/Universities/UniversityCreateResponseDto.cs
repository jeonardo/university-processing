namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityCreateResponseDto
{
    public Guid Id { get; set; }

    public UniversityCreateResponseDto(Guid id)
    {
        Id = id;
    }
}