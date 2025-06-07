namespace UniversityProcessing.Core.Aggregates;

public class DiplomaProcess : AggregateRoot
{
    private readonly List<DiplomaProject> _projects = new();
    private readonly List<Defense> _defenses = new();

    public AcademicPeriod Period { get; }
    public IReadOnlyCollection<DiplomaProject> Projects => _projects.AsReadOnly();
    public IReadOnlyCollection<Defense> Defenses => _defenses.AsReadOnly();

    public DiplomaProcess(AcademicPeriod period)
    {
        Period = period;
    }

    public void ScheduleDefense(DiplomaProject project, DateTime time, GraduationExaminationCommittee gec)
    {
        if (project.Status != DiplomaProjectStatus.Submitted)
        {
            throw new InvalidOperationException("Project not submitted");
        }

        var defense = new Defense(project, time, gec);
        _defenses.Add(defense);
        AddDomainEvent(new DefenseScheduledEvent(defense.Id));
    }
}
