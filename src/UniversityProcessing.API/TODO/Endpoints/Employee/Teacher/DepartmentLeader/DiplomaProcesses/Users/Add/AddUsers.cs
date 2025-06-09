using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Add;

internal sealed class AddUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(AddUsers);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<AddUsersRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] AddUsersRequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        [FromServices] IEfRepository<User> userRepository,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var diplomaPeriod = await repository.GetByIdRequiredAsync(request.DiplomaPeriodId, cancellationToken);
        var userIds = request.UserIds.ToHashSet();
        var missingUsers = await userManager.Users
            .Where(x => userIds.Contains(x.Id) && x.DiplomaProcesses.All(y => y.Id != request.DiplomaPeriodId))
            .Include(x => x.DiplomaProcesses)
            .ToArrayAsync(cancellationToken: cancellationToken);

        foreach (var user in missingUsers)
        {
            diplomaPeriod.Users.Add(user);
        }

        await repository.SaveChangesAsync(cancellationToken);
    }
}
