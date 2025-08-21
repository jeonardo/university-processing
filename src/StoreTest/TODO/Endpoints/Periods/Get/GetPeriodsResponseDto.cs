namespace StoreTest.TODO.Endpoints.Periods.Get;

public sealed class GetPeriodsResponseDto(PagedList<PeriodDto> list)
{
    public PagedList<PeriodDto> List { get; set; } = list;
}
