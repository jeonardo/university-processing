namespace UniversityProcessing.Domain.Users;

public class Deanery : User
{
    public long UniversityPositionId { get; private set; }

    public virtual UniversityPosition UniversityPosition { get; private set; } = null!;

    public long FacultyId { get; private set; }

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
        string? middleName,
        string? email,
        DateTime? birthday,
        string? phoneNumber,
        long universityPositionId,
        long facultyId)
        : base(
            UserRoleType.Deanery,
            userName,
            firstName,
            lastName,
            middleName,
            email,
            birthday,
            phoneNumber)
    {
        UniversityPositionId = universityPositionId;
        FacultyId = facultyId;
    }
}
