using StoreTest.Services.Auth;

namespace StoreTest.TODO.Hubs;

[Authorize]
internal sealed class ApplicationHub(ITokenService tokenService, ILogger<ApplicationHub> logger) : Hub<IServerHubCommandsApi>, IClientHubCommandsApi
{
    public override async Task OnConnectedAsync()
    {
        if (Context.User is null || !tokenService.TryGetAuthorizationTokenClaims(Context.User, out var claims))
        {
            Context.Abort();
            return;
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, claims.UserId.ToString());
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (Context.User is not null && tokenService.TryGetAuthorizationTokenClaims(Context.User, out var claims))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, claims.UserId.ToString());
        }

        if (exception is not null)
        {
            const string hubErrorMessage = "Hub connection was aborted with an error";
            logger.LogError(exception, hubErrorMessage);
        }
    }
}
