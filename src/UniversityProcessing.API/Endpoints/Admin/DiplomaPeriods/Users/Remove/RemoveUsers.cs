using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Users.Remove;

internal sealed class RemoveUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapDelete(NamespaceService.GetEndpointRoute(typeof(RemoveUsers)), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<RemoveUsersRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] RemoveUsersRequestDto request,
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
