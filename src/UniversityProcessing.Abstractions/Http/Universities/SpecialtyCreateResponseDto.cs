namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class SpecialtyCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}