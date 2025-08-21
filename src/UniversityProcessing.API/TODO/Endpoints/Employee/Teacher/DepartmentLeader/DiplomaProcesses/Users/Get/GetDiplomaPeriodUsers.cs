using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Get;

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
            "sfa",
            true);
    }
}
