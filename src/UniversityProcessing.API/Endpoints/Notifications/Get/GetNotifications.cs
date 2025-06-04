using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.API.Services.Notifications;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Routing;

namespace UniversityProcessing.API.Endpoints.Notifications.Get;

internal sealed class GetNotifications : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetNotifications);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<GetNotificationsResponseDto> Handle(
        HttpContext context,
        [AsParameters] GetNotificationsRequestDto requestDto,
        [FromServices] ITokenService tokenService,
        [FromServices] INotificationService notificationService,
        CancellationToken cancellationToken)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);
        var notifications = await notificationService.Get(claims.UserId, requestDto.PageNumber, 10, cancellationToken);
        return new GetNotificationsResponseDto(notifications);
    }
}
