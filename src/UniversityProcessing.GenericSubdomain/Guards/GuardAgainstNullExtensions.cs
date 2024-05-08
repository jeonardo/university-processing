using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;

namespace UniversityProcessing.GenericSubdomain.Guards;

public static class GuardAgainstNullExtensions
{
    public static string? NotNullAndWhiteSpace(
        this IGuardClause guardClause,
        string? input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        if (input is null)
        {
            return null;
        }

        Guard.Against.NullOrEmpty(input, parameterName, message);

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }

        return input;
    }
}