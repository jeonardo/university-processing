namespace UniversityProcessing.API.Endpoints.Specialties.Create;

public sealed class CreateSpecialtyResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
