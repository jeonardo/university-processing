using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Get;

internal sealed class GetEmployees : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(GetEmployees), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<GetEmployeesRequestDto>>();
    }

    private static async Task<GetEmployeesResponseDto> Handle(
        [AsParameters] GetEmployeesRequestDto request,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var employees = await userManager.GetUsersInRoleAsync(nameof(UserRoleType.Employee));
        return new GetEmployeesResponseDto(employees.Select(x => ToDto(x, request)));
    }

    private static EmployeeDto ToDto(User user, GetEmployeesRequestDto request)
    {
        return new EmployeeDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.MiddleName,
            user.UniversityPosition?.Name,
            user.DiplomaPeriods.Any(x => x.Id == request.DiplomaPeriodId));
    }
}
