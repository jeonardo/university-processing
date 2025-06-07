namespace UniversityProcessing.Core.Entities;

public class Faculty : EntityBase

{
    public string Name { get; private set; }

    public string? Description { get; private set; }

    // Навигационные свойства

    public ICollection<Department> Departments { get; private set; } = new List<Department>();

    public ICollection<User> Users { get; private set; } = new List<User>();

    public ICollection<AcademicPeriod> AcademicPeriods { get; private set; } = new List<AcademicPeriod>();

    public ICollection<DeanAssignment> DeanAssignments { get; private set; } = new List<DeanAssignment>();

    // ... методы

    public Faculty(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Бизнес-методы
    public void AddDepartment(string name)
    {
        _departments.Add(new Department(name, this));
    }

    public void StartAcademicPeriod(string name, DateTime startDate, DateTime endDate)
    {
        _academicPeriods.Add(new AcademicPeriod(name, startDate, endDate, this));
    }
}
