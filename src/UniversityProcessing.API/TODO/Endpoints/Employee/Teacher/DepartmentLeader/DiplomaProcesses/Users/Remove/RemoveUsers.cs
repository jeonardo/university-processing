using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Remove;

internal sealed class RemoveUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(RemoveUsers);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<RemoveUsersRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] RemoveUsersRequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        [FromServices] IEfRepository<User> userRepository,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var diplomaPeriod = await repository.GetByIdRequiredAsync(request.DiplomaPeriodId, cancellationToken);
        var userIds = request.UserIds.ToHashSet();
        var existingUsers = await userManager.Users
            .Where(x => userIds.Contains(x.Id) && x.DiplomaProcesses.Any(y => y.Id == request.DiplomaPeriodId))
            .Include(x => x.DiplomaProcesses)
            .ToArrayAsync(cancellationToken: cancellationToken);

        foreach (var user in existingUsers)
        {
            diplomaPeriod.Users.Remove(user);
        }

        await repository.SaveChangesAsync(cancellationToken);
    }
}
