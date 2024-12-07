using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Remove;

internal sealed class RemoveEmployees : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapDelete(nameof(RemoveEmployees), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<RemoveEmployeesRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RemoveEmployeesRequestDto request,
        [FromServices] IEfRepository<DiplomaPeriod> repository,
        [FromServices] IEfRepository<User> userRepository,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var diplomaPeriod = await repository.GetByIdRequiredAsync(request.DiplomaPeriodId, cancellationToken);
        var userIds = request.UserIds.ToHashSet();
        var existingUsers = await userManager.Users
            .Where(x => userIds.Contains(x.Id) && x.DiplomaPeriods.Any(y => y.Id == request.DiplomaPeriodId))
            .Include(x => x.DiplomaPeriods)
            .ToArrayAsync(cancellationToken: cancellationToken);

        foreach (var user in existingUsers)
        {
            diplomaPeriod.Users.Remove(user);
        }

        await repository.SaveChangesAsync(cancellationToken);
    }
}
