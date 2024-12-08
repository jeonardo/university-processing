namespace UniversityProcessing.API.Endpoints.Common.GetDiplomaPeriods;

public sealed class DiplomaPeriodDto(Guid id, string name, DateTime studyPeriodFrom, DateTime studyPeriodTo)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime StudyPeriodFrom { get; set; } = studyPeriodFrom;
    public DateTime StudyPeriodTo { get; set; } = studyPeriodTo;
}
