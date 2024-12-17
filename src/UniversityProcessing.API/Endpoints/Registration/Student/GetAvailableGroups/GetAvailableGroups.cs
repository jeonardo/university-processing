using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Registration.Student.GetAvailableGroups;

internal sealed class GetAvailableGroups : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetAvailableGroups)), Handle)
            .WithTags(Tags.REGISTRATION)
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
