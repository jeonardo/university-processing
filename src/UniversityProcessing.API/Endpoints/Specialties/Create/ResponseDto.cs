namespace UniversityProcessing.API.Endpoints.Specialties.Create;

public sealed class ResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
