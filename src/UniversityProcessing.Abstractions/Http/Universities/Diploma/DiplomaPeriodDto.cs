using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities.Diploma;

public sealed class DiplomaPeriodDto
{
    public Guid Id { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    public DiplomaPeriodDto(Guid id, DateTime startDate, DateTime endDate)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
    }
}
