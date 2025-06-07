namespace UniversityProcessing.Core.Entities;

public class Defense : EntityBase
{
    private readonly List<Grade> _grades = new();
    public DateTime ScheduledDateTime { get; private set; }
    public string Location { get; private set; }
    public decimal? FinalGrade { get; private set; }

    // Навигационные свойства
    public GraduationExaminationCommittee Gec { get; private set; }
    public DiplomaProject DiplomaProject { get; private set; }
    public IReadOnlyCollection<Grade> Grades => _grades.AsReadOnly();

    public Defense(
        DateTime scheduledDateTime,
        string location,
        GraduationExaminationCommittee gec,
        DiplomaProject diplomaProject)
    {
        if (diplomaProject.Gec?.Id != gec.Id)
        {
            throw new ArgumentException("Project not assigned to this GEC");
        }

        ScheduledDateTime = scheduledDateTime;
        Location = location;
        Gec = gec;
        DiplomaProject = diplomaProject;
    }

    // Бизнес-методы
    public void AddGrade(Employee gecMember, decimal value, decimal percentage, string? comment = null)
    {
        if (!Gec.Members.Any(m => m.Employee.Id == gecMember.Id))
        {
            throw new InvalidOperationException("Employee is not a member of GEC");
        }

        _grades.Add(new Grade(gecMember, this, value, percentage, comment));
    }

    public void CalculateFinalGrade()
    {
        if (_grades.Count == 0)
        {
            throw new InvalidOperationException("No grades provided");
        }

        FinalGrade = _grades.Average(g => g.Value);
        DiplomaProject.Status = DiplomaProjectStatus.Defended;
    }
}
