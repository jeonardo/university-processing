using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Departments.Delete;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var entity = await repository.TypedDbContext
                .AsNoTracking()
                .Include(x => x.Specialties)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Department not found");

        if (entity.Specialties.Count != 0)
        {
            throw new ConflictException("Department contains specialties");
        }

        await repository.DeleteAsync(entity, cancellationToken);
    }
}
