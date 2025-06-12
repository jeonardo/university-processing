using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.TODO.Hubs;

public interface IServerHubCommandsApi
{
    Task SendNotification(NotificationDto notification);
}
