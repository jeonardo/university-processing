using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;

namespace UniversityProcessing.API.Endpoints.Users.UpdateBlocking;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapPut(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RequestDto request,
        [FromServices] IHttpContextAccessor contextAccessor,
        [FromServices] UserManager<User> userManager,
        [FromServices] ITokenService tokenService)
    {
        var claims = contextAccessor.HttpContext!.User.GetAuthorizationTokenClaims();

        if (claims.UserId == request.UserId)
        {
            throw new AccessDeniedException();
        }

        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.UserId} not found");

        UserAccessManager.ThrowIfAccessToRoleIsNotAllowed(claims.Role, user.Role);

        user.UpdateBlockingStatus(request.IsBlocked);

        var updateResult = await userManager.UpdateAsync(user);

        if (updateResult.IsFailed())
        {
            throw new ConflictException(updateResult.FullDescription());
        }
    }
}
