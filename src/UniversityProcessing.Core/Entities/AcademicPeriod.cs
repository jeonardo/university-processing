namespace UniversityProcessing.Core.Entities;

public class AcademicPeriod : EntityBase
{
    private readonly List<GraduationExaminationCommittee> _gecs = new();
    public string Name { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    // Навигационные свойства
    public Faculty Faculty { get; private set; }
    public DiplomaPeriod? DiplomaPeriod { get; private set; }
    public IReadOnlyCollection<GraduationExaminationCommittee> Gecs => _gecs.AsReadOnly();

    public AcademicPeriod(
        string name,
        DateTime startDate,
        DateTime endDate,
        Faculty faculty)
    {
        if (startDate >= endDate)
        {
            throw new ArgumentException("End date must be after start date");
        }

        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Faculty = faculty;
    }

    // Бизнес-методы
    public void SetDiplomaPeriod(DateTime startDate, DateTime endDate)
    {
        if (startDate < StartDate || endDate > EndDate)
        {
            throw new ArgumentException("Diploma period must be within academic period");
        }

        DiplomaPeriod = new DiplomaPeriod(startDate, endDate, this);
    }
}
