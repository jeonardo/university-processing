namespace UniversityProcessing.API.Endpoints.Admin.CreateUniversity;

public sealed class CreateUniversityResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
