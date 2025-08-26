using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Users.UpdateBlocking;

internal sealed class UpdateBlocking : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(UpdateBlocking);
        app
            .MapPut(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin), nameof(UserRoleType.Deanery), nameof(UserRoleType.Teacher)))
            .AddEndpointFilter<ValidationFilter<UpdateBlockingRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] UpdateBlockingRequestDto request,
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
