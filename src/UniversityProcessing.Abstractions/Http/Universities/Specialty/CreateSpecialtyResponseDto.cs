namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class CreateSpecialtyResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
