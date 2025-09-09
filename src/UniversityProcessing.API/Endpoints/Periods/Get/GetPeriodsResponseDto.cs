namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class GetPeriodsResponseDto(PeriodDto[] list)
{
    public PeriodDto[] List { get; set; } = list;
}
