namespace UniversityProcessing.Domain.Users;

public class Student : User
{
    public long GroupId { get; private set; }

    public virtual Group Group { get; private set; } = null!;
    public long? DiplomaId { get; private set; }

    public virtual Diploma? Diploma { get; private set; }

    public long? DefenseSessionId { get; private set; }

    public virtual DefenseSession? DefenseSession { get; private set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Student()
    {
    }

    public Student(
        string userName,
        string firstName,
        string lastName,
        string? middleName,
        string? email,
        DateTime? birthday,
        string? phoneNumber,
        long groupId,
        long? diplomaId = null,
        long? defenseSessionId = null)
        : base(
            UserRoleType.Student,
            userName,
            firstName,
            lastName,
            middleName,
            email,
            birthday,
            phoneNumber)
    {
        GroupId = groupId;
        DiplomaId = diplomaId;
        DefenseSessionId = defenseSessionId;
    }

    public void SetSession(long? sessionId)
    {
        DefenseSessionId = sessionId;
    }
}
