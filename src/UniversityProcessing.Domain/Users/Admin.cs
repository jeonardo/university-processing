namespace UniversityProcessing.Domain.Users;

public class Admin : User
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
        DateTime? birthday = null,
        string? phoneNumber = null)
        : base(
            userName,
            firstName,
            lastName,
            middleName,
            email,
            birthday,
            phoneNumber)
    {
    }
}
