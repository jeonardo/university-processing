using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Services.Notifications;

internal sealed class NotificationService : INotificationService
{
    public Task<NotificationDto[]> Get(Guid userId, int page, int size, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
