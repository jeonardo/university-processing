using System.Text.Json;

namespace UniversityProcessing.GenericSubdomain.Http;

/// <summary>
///     Base class used by API responses
/// </summary>
public abstract class BaseResponse(
    bool success,
    string? message = null)
{
    public bool Success { get; private init; } = success;

    public string? Message { get; private init; } = message;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}