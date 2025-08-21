namespace StoreTest.Services.Notifications;

internal sealed class NotificationService : INotificationService
{
    public Task<NotificationDto[]> Get(Guid userId, int page, int size, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
