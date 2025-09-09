using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Get;

internal sealed class GetDiplomaProcesses : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetDiplomaProcesses);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<GetDiplomaProcessesResponseDto> Handle(
        [AsParameters] GetDiplomaProcessesRequestDto request,
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
        return new GetDiplomaProcessesResponseDto(entities);
    }
}
