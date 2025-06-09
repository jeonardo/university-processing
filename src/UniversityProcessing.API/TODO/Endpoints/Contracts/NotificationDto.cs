namespace UniversityProcessing.API.TODO.Endpoints.Contracts;

public sealed class NotificationDto(string title, string message)
{
    public string Title { get; init; } = title;

    public string Message { get; init; } = message;
}
