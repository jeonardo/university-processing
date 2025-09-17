namespace UniversityProcessing.Domain.Users;

public class Student : User
{
    public Guid GroupId { get; private set; }

    public virtual Group Group { get; private set; } = null!;
    public Guid? DiplomaId { get; private set; }

    public virtual Diploma? Diploma { get; private set; }

    public Guid? DiplomaProcessId { get; private set; }

    public virtual DiplomaProcess? DiplomaProcess { get; private set; } = null!;

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
        Guid groupId,
        Guid? diplomaId = null,
        Guid? diplomaProcessId = null)
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
        DiplomaProcessId = diplomaProcessId;
    }
}
