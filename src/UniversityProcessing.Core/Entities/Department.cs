namespace UniversityProcessing.Core.Entities;

public class Department : EntityBase
{
    private readonly List<Specialty> _specialties = new();
    public string Name { get; private set; }

    // Навигационные свойства
    public Faculty Faculty { get; private set; }
    public Employee? Head { get; private set; }
    public IReadOnlyCollection<Specialty> Specialties => _specialties.AsReadOnly();

    public Department(string name, Faculty faculty)
    {
        Name = name;
        Faculty = faculty ?? throw new ArgumentNullException(nameof(faculty));
    }

    // Бизнес-методы
    public void AssignHead(Employee employee)
    {
        if (employee.DepartmentAssignments.Any(a => a.IsActive()))
        {
            throw new InvalidOperationException("Employee is already department head");
        }

        Head = employee;
    }

    public void AddSpecialty(string code, string name)
    {
        _specialties.Add(new Specialty(code, name, this));
    }
}
