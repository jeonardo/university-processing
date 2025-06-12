using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Deanery.Departments.Delete;

internal sealed class DeleteDepartment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeleteDepartment);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteDepartmentRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteDepartmentRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        await repository.DeleteAsync(entity, cancellationToken);
    }
}
