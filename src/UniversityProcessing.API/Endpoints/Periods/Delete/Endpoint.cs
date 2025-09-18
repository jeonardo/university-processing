using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Periods.Delete;

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
        [FromServices] IEfRepository<Period> repository,
        CancellationToken cancellationToken)
    {
        var entity = await repository.TypedDbContext
                .AsNoTracking()
                .Include(x => x.Groups)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Period not found");

        if (entity.Groups.Count != 0)
        {
            throw new ConflictException("Period contains groups");
        }

        await repository.DeleteAsync(entity, cancellationToken);
    }
}
