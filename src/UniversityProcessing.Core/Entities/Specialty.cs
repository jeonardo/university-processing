namespace UniversityProcessing.Core.Entities;

public class Specialty : EntityBase
{
    private readonly List<Student> _students = new();
    private readonly List<GecSpecialty> _gecSpecialties = new();
    public string Code { get; private set; }
    public string Name { get; private set; }

    // Навигационные свойства
    public Department Department { get; private set; }

    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
    public IReadOnlyCollection<GecSpecialty> GecSpecialties => _gecSpecialties.AsReadOnly();

    public Specialty(string code, string name, Department department)
    {
        Code = code;
        Name = name;
        Department = department;
    }
}
