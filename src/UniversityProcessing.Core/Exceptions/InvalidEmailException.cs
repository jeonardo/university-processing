namespace UniversityProcessing.Core.Exceptions;

public class InvalidEmailException : DomainException
{
    public string InvalidEmail { get; }

    public InvalidEmailException(string email)
        : base($"Invalid email format: {email}")
    {
        InvalidEmail = email;
    }
}
