using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Users.Get;

internal sealed class GetDiplomaPeriodUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetDiplomaPeriodUsers)), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<GetDiplomaPeriodUsersRequestDto>>();
    }

    private static async Task<GetDiplomaPeriodUsersResponseDto> Handle(
        [AsParameters] GetDiplomaPeriodUsersRequestDto request,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var users = await userManager.GetUsersInRoleAsync(request.RoleType.GetDisplayName());
        return new GetDiplomaPeriodUsersResponseDto(users.Select(x => ToDto(x, request)));
    }

    private static DiplomaPeriodUserDto ToDto(User user, GetDiplomaPeriodUsersRequestDto request)
    {
        return new DiplomaPeriodUserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.MiddleName,
            user.UniversityPosition?.Name,
            user.DiplomaPeriods.Any(x => x.Id == request.DiplomaPeriodId));
    }
}
