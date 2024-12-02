namespace UniversityProcessing.API.Endpoints.Admin.Specialties.Create;

public sealed class CreateSpecialtyResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
