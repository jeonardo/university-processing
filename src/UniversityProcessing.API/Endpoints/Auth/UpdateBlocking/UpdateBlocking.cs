using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Auth.Common;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Middlewares.Exceptions;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.UpdateBlocking;

internal sealed class UpdateBlocking : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(UpdateBlocking);
        app
            .MapPut(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin), nameof(UserRoleType.Deanery)))
            .AddEndpointFilter<ValidationFilter<UpdateBlockingRequestDto>>();
    }

    private static async Task Handle(
        HttpContext context,
        [FromBody] UpdateBlockingRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ITokenService tokenService)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);

        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.UserId} not found");

        var userRoles = await userManager.GetRolesAsync(user);

        AuthCommon.ThrowIfRoleIsNotAllowed(claims.RoleType, Enum.Parse<UserRoleType>(userRoles.First()));

        user.UpdateBlockingStatus(request.IsBlocked);

        var updateResult = await userManager.UpdateAsync(user);

        if (updateResult.IsFailed())
        {
            throw new ConflictException(updateResult.FullDescription());
        }
    }
}
