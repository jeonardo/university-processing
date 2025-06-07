namespace UniversityProcessing.Core.ValueObjects;

public sealed record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (!IsValidEmail(value))
        {
            throw new InvalidEmailException(value);
        }

        Value = value;
    }

    private static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public override string ToString()
    {
        return Value;
    }
}
