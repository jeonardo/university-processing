namespace UniversityProcessing.Core.Entities;

public class GraduationExaminationCommittee : EntityBase
{
    private readonly List<GecMember> _members = new();
    private readonly List<GecSpecialty> _specialties = new();
    private readonly List<Defense> _defenses = new();
    public string Name { get; private set; }
    public int MaxStudentsPerSupervisor { get; private set; }

    // Навигационные свойства
    public AcademicPeriod AcademicPeriod { get; private set; }
    public ICollection<GecMember> Members { get; private set; } = new List<GecMember>();
    public ICollection<GecSpecialty> Specialties { get; private set; } = new List<GecSpecialty>();
    public ICollection<Defense> Defenses { get; private set; } = new List<Defense>();

    public GraduationExaminationCommittee(
        string name,
        int maxStudentsPerSupervisor,
        AcademicPeriod academicPeriod)
    {
        Name = name;
        MaxStudentsPerSupervisor = maxStudentsPerSupervisor;
        AcademicPeriod = academicPeriod;
    }

    // Бизнес-методы
    public void AddMember(Employee employee)
    {
        if (_members.Any(m => m.Employee.Id == employee.Id))
        {
            throw new InvalidOperationException("Employee is already in GEC");
        }

        _members.Add(new GecMember(this, employee));
    }

    public void ScheduleDefense(DateTime dateTime, string location)
    {
        _defenses.Add(new Defense(dateTime, location, this));
    }
}
