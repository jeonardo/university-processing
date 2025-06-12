using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Delete;

internal sealed class DeleteGroup : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeleteGroup);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteGroupRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteGroupRequestDto request,
        [FromServices] IEfRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        await repository.DeleteAsync(record, cancellationToken);
    }
}
