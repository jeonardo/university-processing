namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Create;

public sealed class CreateDiplomaPeriodResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}
