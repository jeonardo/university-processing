using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Get;

internal sealed class GetDiplomaPeriodUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetDiplomaPeriodUsers);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
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
            user.DiplomaProcesses.Any(x => x.Id == request.DiplomaPeriodId));
    }
}
