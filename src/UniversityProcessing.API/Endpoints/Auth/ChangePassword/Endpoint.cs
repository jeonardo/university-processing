using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;

namespace UniversityProcessing.API.Endpoints.Auth.ChangePassword;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RequestDto>>()
            .RequireAuthorization();
    }

    private static async Task Handle(
        [FromBody] RequestDto request,
        [FromServices] IHttpContextAccessor contextAccessor,
        [FromServices] UserManager<User> userManager,
        [FromServices] ILogger<Endpoint> logger,
        CancellationToken cancellationToken)
    {
        var claims = contextAccessor.HttpContext!.User.GetAuthorizationTokenClaims();
        var user = await userManager.FindByIdAsync(claims.UserId.ToString())
            ?? throw new NotFoundException("User not found");

        var createResult = await userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"The password wasn't changed. Message = {createResult.FullDescription()}");
        }
    }
}
