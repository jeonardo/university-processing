using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableUniversityPositions;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type));
    }

    private static async Task<ResponseDto> Handle(
        [FromServices] IEfReadRepository<UniversityPosition> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext
            .AsNoTracking()
            .Select(x => new UniversityPositionDto(x.Id, x.Name))
            .ToArrayAsync(cancellationToken);
        return new ResponseDto(entities);
    }
}
