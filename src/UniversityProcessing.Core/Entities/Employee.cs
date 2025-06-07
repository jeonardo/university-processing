namespace UniversityProcessing.Core.Entities;

public class Employee : User
{
    public string? Position { get; private set; }

    // Навигационные свойства

    public IReadOnlyCollection<DeanAssignment> DeanAssignments => _deanAssignments.AsReadOnly();
    public IReadOnlyCollection<DepartmentAssignment> DepartmentAssignments => _departmentAssignments.AsReadOnly();

    public ICollection<DiplomaTheme> DiplomaThemes { get; private set; } = new List<DiplomaTheme>();

    public ICollection<GecMember> GecMemberships { get; private set; } = new List<GecMember>();

    public ICollection<DiplomaProject> SupervisedProjects { get; private set; } = new List<DiplomaProject>();

    public ICollection<Review> Reviews { get; private set; } = new List<Review>();

    public ICollection<SupervisorRequest> SupervisorRequests { get; private set; } = new List<SupervisorRequest>();

    public Employee(PersonalName name, Email email, string passwordHash)
        : base(name, email, passwordHash)
    {
    }

    // Бизнес-методы
    public void AssignAsDean(Faculty faculty, DateTime startDate, DateTime? endDate = null)
    {
        if (_deanAssignments.Any(a => a.IsActive()))
        {
            throw new InvalidOperationException("User is already a dean");
        }

        _deanAssignments.Add(new DeanAssignment(faculty, this, startDate, endDate));
    }

    public void ProposeTheme(string title, string description)
    {
        _proposedThemes.Add(new DiplomaTheme(title, description, this));
    }
}
