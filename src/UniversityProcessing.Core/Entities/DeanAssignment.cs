namespace UniversityProcessing.Core.Entities;

public class DeanAssignment : EntityBase
{
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    // Навигационные свойства
    public Faculty Faculty { get; private set; }
    public Employee Dean { get; private set; }

    public DeanAssignment(
        Faculty faculty,
        Employee dean,
        DateTime startDate,
        DateTime? endDate = null)
    {
        if (startDate > endDate && endDate.HasValue)
        {
            throw new ArgumentException("End date must be after start date");
        }

        Faculty = faculty;
        Dean = dean;
        StartDate = startDate;
        EndDate = endDate;
    }

    public bool IsActive()
    {
        return EndDate == null || EndDate > DateTime.UtcNow;
    }
}
