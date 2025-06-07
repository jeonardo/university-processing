namespace UniversityProcessing.Core.Entities;

public class SupervisorRequest : EntityBase
{
    public RequestStatus Status { get; private set; }
    public DateTime RequestDate { get; } = DateTime.UtcNow;
    public DateTime? ResponseDate { get; private set; }

    // Навигационные свойства
    public Student Student { get; private set; }
    public Employee Supervisor { get; private set; }
    public DiplomaTheme ProposedTheme { get; private set; }

    public SupervisorRequest(
        Student student,
        Employee supervisor,
        DiplomaTheme proposedTheme)
    {
        Student = student;
        Supervisor = supervisor;
        ProposedTheme = proposedTheme;
        Status = RequestStatus.Pending;
    }

    // Бизнес-методы
    public void Accept()
    {
        if (Status != RequestStatus.Pending)
        {
            throw new InvalidOperationException("Request already processed");
        }

        Status = RequestStatus.Accepted;
        ResponseDate = DateTime.UtcNow;
        Student.StartDiplomaProject(Supervisor, ProposedTheme);
    }

    public void Reject()
    {
        if (Status != RequestStatus.Pending)
        {
            throw new InvalidOperationException("Request already processed");
        }

        Status = RequestStatus.Rejected;
        ResponseDate = DateTime.UtcNow;
    }
}
