using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.GenericSubdomain.Namespace;

namespace UniversityProcessing.API.Endpoints.Admin.Users.UpdateApproval;

internal sealed class UpdateApproval : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPut(NamespaceService.GetEndpointRoute(typeof(UpdateApproval)), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<UpdateApprovalRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] UpdateApprovalRequestDto request,
        [FromServices] UserManager<User> userManager)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.UserId} not found");

        user.UpdateIsApprovedStatus(request.IsApproved);

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            throw new ConflictException(updateResult.Errors.ToString() ?? "User status wasn't changed");
        }
    }
}
