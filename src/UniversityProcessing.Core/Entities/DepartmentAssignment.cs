namespace UniversityProcessing.Core.Entities;

public class DepartmentAssignment : EntityBase
{
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    // Навигационные свойства
    public Department Department { get; private set; }
    public Employee Head { get; private set; }

    public DepartmentAssignment(
        Department department,
        Employee head,
        DateTime startDate,
        DateTime? endDate = null)
    {
        if (startDate > endDate && endDate.HasValue)
        {
            throw new ArgumentException("End date must be after start date");
        }

        Department = department;
        Head = head;
        StartDate = startDate;
        EndDate = endDate;
    }

    public bool IsActive()
    {
        return EndDate == null || EndDate > DateTime.UtcNow;
    }
}
