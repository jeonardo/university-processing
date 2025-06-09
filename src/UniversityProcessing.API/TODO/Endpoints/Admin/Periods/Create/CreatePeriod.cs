using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Periods.Create;

internal sealed class CreatePeriod : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreatePeriod);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<CreatePeriodRequestDto>>();
    }

    private static async Task<CreatePeriodResponseDto> Handle(
        [FromBody] CreatePeriodRequestDto request,
        [FromServices] IEfRepository<Period> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Period.Create(request.From, request.To, request.Comments);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreatePeriodResponseDto(newEntity.Id);
    }
}
