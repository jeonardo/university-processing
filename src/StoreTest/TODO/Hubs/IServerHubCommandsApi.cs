namespace StoreTest.TODO.Hubs;

public interface IServerHubCommandsApi
{
    Task SendNotification(NotificationDto notification);
}
