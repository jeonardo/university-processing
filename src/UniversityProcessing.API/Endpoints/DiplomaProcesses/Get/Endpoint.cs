using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Get;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext
            .AsNoTracking()
            .ToPagedListAsync(
                request,
                x => x.PeriodId == request.PeriodId,
                x => new DiplomaProcessDto(x.Id, x.Name),
                null,
                cancellationToken);
        return new ResponseDto(entities);
    }
}
