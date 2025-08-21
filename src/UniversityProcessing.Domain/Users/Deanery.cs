namespace UniversityProcessing.Domain.Users;

public class Deanery : User
{
    public Guid UniversityPositionId { get; private set; }

    public virtual UniversityPosition UniversityPosition { get; private set; } = null!;

    public Guid FacultyId { get; private set; }

    public virtual Faculty Faculty { get; private set; } = null!;

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Deanery()
    {
    }

    public Deanery(
        string userName,
        string firstName,
        string lastName,
        Guid universityPositionId,
        Guid facultyId,
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
        FacultyId = facultyId;
    }
}
