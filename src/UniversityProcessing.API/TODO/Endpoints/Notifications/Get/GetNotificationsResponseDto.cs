using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.TODO.Endpoints.Notifications.Get;

public sealed class GetNotificationsResponseDto(IEnumerable<NotificationDto> notifications)
{
    public IEnumerable<NotificationDto> Notifications { get; init; } = notifications;
}
