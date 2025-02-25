namespace UniversityProcessing.API.Endpoints.Admin.Periods.Create;

public sealed class CreatePeriodResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
