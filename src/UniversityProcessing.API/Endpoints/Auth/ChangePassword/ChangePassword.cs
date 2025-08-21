using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Middlewares.Exceptions;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.ChangePassword;

internal sealed class ChangePassword : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(ChangePassword);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<ChangePasswordRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] ChangePasswordRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ILogger<ChangePassword> logger,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName)
            ?? throw new NotFoundException($"User with username = {request.UserName} not found");

        var createResult = await userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"The password wasn't changed. Message = {createResult.FullDescription()}");
        }
    }
}
