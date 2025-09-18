using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Groups.Get;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
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
        return new ResponseDto(entities);
    }
}
