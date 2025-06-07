namespace UniversityProcessing.Core.Entities;

public class DiplomaPeriod : EntityBase
{
    private readonly List<DiplomaProject> _diplomaProjects = new();
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    // Навигационные свойства
    public AcademicPeriod AcademicPeriod { get; private set; }
    public IReadOnlyCollection<DiplomaProject> DiplomaProjects => _diplomaProjects.AsReadOnly();

    public DiplomaPeriod(
        DateTime startDate,
        DateTime endDate,
        AcademicPeriod academicPeriod)
    {
        if (startDate >= endDate)
        {
            throw new ArgumentException("End date must be after start date");
        }

        StartDate = startDate;
        EndDate = endDate;
        AcademicPeriod = academicPeriod;
    }
}
