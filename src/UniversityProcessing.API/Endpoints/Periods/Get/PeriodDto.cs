namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class PeriodDto(Guid id, DateTime from, DateTime to, string? comments)
{
    public Guid Id { get; set; } = id;
    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;
    public string? Comments { get; set; } = comments;
}
