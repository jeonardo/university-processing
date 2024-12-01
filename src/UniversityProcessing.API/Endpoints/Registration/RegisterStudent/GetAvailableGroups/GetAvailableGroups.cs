using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterStudent.GetAvailableGroups;

internal sealed class GetAvailableGroups : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(GetAvailableGroups), Handle)
            .WithTags(Tags.REGISTRATION_STUDENT)
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
