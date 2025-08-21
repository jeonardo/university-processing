namespace StoreTest.Services.Notifications;

public interface INotificationService
{
    Task<NotificationDto[]> Get(Guid userId, int page, int size, CancellationToken cancellationToken);
}
