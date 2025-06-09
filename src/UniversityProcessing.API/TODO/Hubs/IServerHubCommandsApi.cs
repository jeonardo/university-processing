using UniversityProcessing.API.TODO.Endpoints.Contracts;

namespace UniversityProcessing.API.TODO.Hubs;

public interface IServerHubCommandsApi
{
    Task SendNotification(NotificationDto notification);
}
