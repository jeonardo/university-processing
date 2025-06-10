using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Student.GetAvailableGroups;

internal sealed class GetAvailableGroups : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetAvailableGroups);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<GetAvailableGroupsRequestDto>>();
    }

    private static async Task<GetAvailableGroupsResponseDto> Handle(
        [AsParameters] GetAvailableGroupsRequestDto request,
        [FromServices] IEfReadRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var specification = new GetAvailableGroupsSpecification(request.Number);
        var groups = await repository.ListAsync(specification, cancellationToken);
        return new GetAvailableGroupsResponseDto(groups.ToArray());
    }
}
