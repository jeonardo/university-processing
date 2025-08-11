namespace UniversityProcessing.Domain.Users;

public sealed class Admin : User
{
    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Admin()
    {
    }

    public Admin(
        string userName,
        string firstName,
        string lastName,
        string? middleName = null,
        string? email = null,
        DateTime? birthday = null)
        : base(
            UserRoleType.Admin,
            userName,
            firstName,
            lastName,
            middleName,
            email,
            birthday)
    {
    }
}
