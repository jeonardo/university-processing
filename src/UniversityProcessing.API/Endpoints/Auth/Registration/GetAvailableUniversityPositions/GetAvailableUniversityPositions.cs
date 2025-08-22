using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableUniversityPositions;

internal sealed class GetAvailableUniversityPositions : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetAvailableUniversityPositions);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type));
    }

    private static async Task<GetAvailableUniversityPositionsResponseDto> Handle(
        [FromServices] IEfReadRepository<UniversityPosition> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext
            .AsNoTracking()
            .Select(x => new UniversityPositionDto(x.Id, x.Name))
            .ToArrayAsync(cancellationToken);
        return new GetAvailableUniversityPositionsResponseDto(entities);
    }
}
