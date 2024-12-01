namespace UniversityProcessing.API.Endpoints.Admin.Universities.Create;

public sealed class CreateUniversityResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
