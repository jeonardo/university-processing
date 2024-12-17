using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversities;

internal sealed class GetAvailableUniversities : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetAvailableUniversities)), Handle)
            .WithTags(Tags.REGISTRATION)
            .AddEndpointFilter<ValidationFilter<GetAvailableUniversitiesRequestDto>>();
    }

    private static async Task<GetAvailableUniversitiesResponseDto> Handle(
        [AsParameters] GetAvailableUniversitiesRequestDto request,
        [FromServices] IEfRepository<University> repository,
        CancellationToken cancellationToken)
    {
        var specification = new GetAvailableUniversitiesSpecification(request.Name);
        var entities = await repository.ListAsync(specification, cancellationToken);
        return new GetAvailableUniversitiesResponseDto(entities.ToArray());
    }
}
