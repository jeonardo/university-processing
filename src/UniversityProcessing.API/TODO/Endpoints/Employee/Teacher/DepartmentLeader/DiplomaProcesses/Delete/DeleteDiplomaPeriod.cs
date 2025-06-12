using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Delete;

internal sealed class DeleteDiplomaPeriod : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeleteDiplomaPeriod);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteDiplomaPeriodRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteDiplomaPeriodRequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        await repository.DeleteAsync(record, cancellationToken);
    }
}
