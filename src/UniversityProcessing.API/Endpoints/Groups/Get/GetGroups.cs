using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Groups.Get;

internal sealed class GetGroups : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetGroups);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<GetGroupsResponseDto> Handle(
        [AsParameters] GetGroupsRequestDto request,
        [FromServices] IEfReadRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext.ToPagedListAsync(
            request,
            request.Filter is null
                ? x => x.PeriodId == request.PeriodId
                : x => x.PeriodId == request.PeriodId && x.Number.Contains(request.Filter),
            x => new GroupDto(x.Id, x.Number),
            null,
            cancellationToken);
        return new GetGroupsResponseDto(entities);
    }
}
