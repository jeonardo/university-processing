namespace UniversityProcessing.API.Endpoints.Common.GetDiplomaPeriods;

public sealed class DiplomaPeriodDto(Guid id, DateTime startDate, DateTime endDate)
{
    public Guid Id { get; set; } = id;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
}
