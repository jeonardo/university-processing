using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities.Diploma;

public sealed class DiplomaPeriodDto(Guid id, DateTime startDate, DateTime endDate)
{
    public Guid Id { get; set; } = id;

    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; } = startDate;

    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; } = endDate;
}
