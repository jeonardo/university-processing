using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Hubs;

public interface IServerHubCommandsApi
{
    Task SendNotification(NotificationDto notification);
}
