namespace UniversityProcessing.Core.Entities;

public class DiplomaProject : EntityBase
{
    private readonly List<Review> _reviews = new();
    public DiplomaProjectStatus Status { get; private set; }
    public DateTime? SubmissionDate { get; private set; }
    public FilePath? WorkFile { get; private set; }

    // Навигационные свойства
    public Student Student { get; private set; }
    public Employee Supervisor { get; private set; }
    public DiplomaTheme Theme { get; private set; }
    public GraduationExaminationCommittee? Gec { get; private set; }
    public Defense? Defense { get; private set; }
    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

    public DiplomaProject(
        Student student,
        Employee supervisor,
        DiplomaTheme theme)
    {
        Student = student;
        Supervisor = supervisor;
        Theme = theme;
        Status = DiplomaProjectStatus.Draft;
    }

    // Бизнес-методы
    public void SubmitWork(FilePath file)
    {
        if (Status != DiplomaProjectStatus.Draft)
        {
            throw new InvalidOperationException("Project already submitted");
        }

        WorkFile = file;
        SubmissionDate = DateTime.UtcNow;
        Status = DiplomaProjectStatus.Submitted;
        AddDomainEvent(new DiplomaProjectSubmittedEvent(Id));
    }

    public void AssignToGec(GraduationExaminationCommittee gec)
    {
        if (Status != DiplomaProjectStatus.Submitted)
        {
            throw new InvalidOperationException("Project not submitted");
        }

        Gec = gec;
    }
}
