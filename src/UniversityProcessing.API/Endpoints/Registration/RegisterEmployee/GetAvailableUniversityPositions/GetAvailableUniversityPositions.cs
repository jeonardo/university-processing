using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterEmployee.GetAvailableUniversityPositions;

internal sealed class GetAvailableUniversityPositions : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(GetAvailableUniversityPositions), Handle)
            .WithTags(Tags.REGISTRATION_EMPLOYEE);
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
