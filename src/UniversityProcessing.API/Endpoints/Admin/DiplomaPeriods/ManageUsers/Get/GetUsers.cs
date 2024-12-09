using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageUsers.Get;

internal sealed class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(GetUsers), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<GetUsersRequestDto>>();
    }

    private static async Task<GetUsersResponseDto> Handle(
        [AsParameters] GetUsersRequestDto request,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var users = await userManager.GetUsersInRoleAsync(request.Role.GetDisplayName());
        return new GetUsersResponseDto(users.Select(x => ToDto(x, request)));
    }

    private static UserDto ToDto(User user, GetUsersRequestDto request)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.MiddleName,
            user.UniversityPosition?.Name,
            user.DiplomaPeriods.Any(x => x.Id == request.DiplomaPeriodId));
    }
}
