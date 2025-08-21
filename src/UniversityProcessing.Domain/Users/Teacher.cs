namespace UniversityProcessing.Domain.Users;

public class Teacher : User
{
    public Guid UniversityPositionId { get; private set; }

    public virtual UniversityPosition UniversityPosition { get; private set; } = null!;

    public Guid DepartmentId { get; private set; }

    public virtual Department Department { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Teacher()
    {
    }

    public Teacher(
        string userName,
        string firstName,
        string lastName,
        Guid universityPositionId,
        Guid departmentId,
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
        UniversityPositionId = universityPositionId;
        DepartmentId = departmentId;
    }
}
