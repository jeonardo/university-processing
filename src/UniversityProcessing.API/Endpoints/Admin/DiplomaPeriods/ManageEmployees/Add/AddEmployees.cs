using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Add;

internal sealed class AddEmployees : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(nameof(AddEmployees), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<AddEmployeesRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] AddEmployeesRequestDto request,
        [FromServices] IEfRepository<DiplomaPeriod> repository,
        [FromServices] IEfRepository<User> userRepository,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var diplomaPeriod = await repository.GetByIdRequiredAsync(request.DiplomaPeriodId, cancellationToken);
        var userIds = request.UserIds.ToHashSet();
        var missingUsers = await userManager.Users
            .Where(x => userIds.Contains(x.Id) && x.DiplomaPeriods.All(y => y.Id != request.DiplomaPeriodId))
            .Include(x => x.DiplomaPeriods)
            .ToArrayAsync(cancellationToken: cancellationToken);

        foreach (var user in missingUsers)
        {
            diplomaPeriod.Users.Add(user);
        }

        await repository.SaveChangesAsync(cancellationToken);
    }
}
