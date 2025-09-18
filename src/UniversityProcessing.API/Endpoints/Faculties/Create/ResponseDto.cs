namespace UniversityProcessing.API.Endpoints.Faculties.Create;

public sealed class ResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
