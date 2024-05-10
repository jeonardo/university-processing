namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class SpecialtyCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}