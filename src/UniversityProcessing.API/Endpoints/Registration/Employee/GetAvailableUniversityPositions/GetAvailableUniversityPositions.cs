using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversityPositions;

internal sealed class GetAvailableUniversityPositions : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetAvailableUniversityPositions)), Handle)
            .WithTags(Tags.REGISTRATION);
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
