using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Periods.Create;

internal sealed class CreatePeriod : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreatePeriod);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<CreatePeriodRequestDto>>();
    }

    private static async Task<CreatePeriodResponseDto> Handle(
        [FromBody] CreatePeriodRequestDto request,
        [FromServices] IEfRepository<Period> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Period.Create(request.Name, request.From, request.To, request.Comments);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreatePeriodResponseDto(newEntity.Id);
    }
}
