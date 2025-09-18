namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class ResponseDto(PeriodDto[] list)
{
    public PeriodDto[] List { get; set; } = list;
}
