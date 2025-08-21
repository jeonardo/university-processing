namespace UniversityProcessing.Domain.Users;

public class Student : User
{
    public Guid GroupId { get; private set; }

    public virtual Group Group { get; private set; } = null!;
    public Guid? DiplomaId { get; private set; }

    public virtual Diploma? Diploma { get; private set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Student()
    {
    }

    public Student(
        string userName,
        string firstName,
        string lastName,
        Guid groupId,
        Guid? diplomaId = null,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null)
        : base(
            userName,
            firstName,
            lastName,
            middleName,
            email,
            birthday)
    {
        GroupId = groupId;
        DiplomaId = diplomaId;
    }
}
