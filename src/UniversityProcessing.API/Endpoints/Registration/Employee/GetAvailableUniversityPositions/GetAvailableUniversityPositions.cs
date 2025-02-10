using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversityPositions;

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
        var specification = new GetAvailableUniversityPositionsSpecification();
        var entities = await repository.ListAsync(specification, cancellationToken);
        return new GetAvailableUniversityPositionsResponseDto(entities.ToArray());
    }
}
