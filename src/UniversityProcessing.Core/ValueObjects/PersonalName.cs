namespace UniversityProcessing.Core.ValueObjects;

public sealed record PersonalName
{
    public string FirstName { get; }
    public string LastName { get; }

    public string FullName => $"{FirstName} {LastName}";

    public PersonalName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name required");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name required");
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }
}
