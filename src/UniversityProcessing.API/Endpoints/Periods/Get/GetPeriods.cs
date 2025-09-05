using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Periods.Get;

internal sealed class GetPeriods : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetPeriods);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<GetPeriodsRequestDto>>();
    }

    private static async Task<GetPeriodsResponseDto> Handle(
        [AsParameters] GetPeriodsRequestDto request,
        [FromServices] IEfRepository<Period> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext
            .AsNoTracking()
            .OrderBy(x => x.From)
            .ToPagedListAsync(
                request,
                null,
                x => new PeriodDto(x.Id, x.Name, x.From, x.To, x.Comments),
                null,
                cancellationToken);
        return new GetPeriodsResponseDto(entities);
    }
}
