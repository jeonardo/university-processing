using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Users.UpdateVerification;

internal sealed class UpdateVerification : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(UpdateVerification);
        app
            .MapPut(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<UpdateVerificationRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] UpdateVerificationRequestDto request,
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

        user.UpdateVerificationStatus(request.IsApproved);

        var updateResult = await userManager.UpdateAsync(user);

        if (updateResult.IsFailed())
        {
            throw new ConflictException(updateResult.FullDescription());
        }
    }
}
