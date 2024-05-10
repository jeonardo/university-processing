using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities.Diploma;

public sealed class DiplomaPeriodDto
{
    public Guid Id { get; set; }

    [DataType(DataType.DateTime)]
    public DateOnly StartDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateOnly EndDate { get; set; }

    public DiplomaPeriodDto(Guid id, DateOnly startDate, DateOnly endDate)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
    }
}