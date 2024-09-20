using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;

namespace UniversityProcessing.GenericSubdomain.Guards;

public static class GuardClauseExtensions
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

    public static T NullOrDefault<T>(
        this IGuardClause guardClause,
        T? input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct

    {
        if (input is null)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(parameterName);
            }

            throw new ArgumentNullException(parameterName, message);
        }

        if (Equals(input, default(T)!) || input is null)
        {
            throw new ArgumentException(message ?? $"Parameter [{parameterName}] is default value for type {typeof(T).Name}", parameterName);
        }

        return input.Value;
    }
}
