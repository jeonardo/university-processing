using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableGroups;

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
        var groups = await
            (string.IsNullOrWhiteSpace(request.Number)
                ? repository.TypedDbContext
                : repository.TypedDbContext.Where(g => EF.Functions.Like(g.Number, $"%{request.Number}%")))
            .OrderBy(g => g.Number)
            .Select(g => g.Number)
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new GetAvailableGroupsResponseDto(groups);
    }
}
