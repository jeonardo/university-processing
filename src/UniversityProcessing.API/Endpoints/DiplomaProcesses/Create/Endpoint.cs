using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Create;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = DiplomaProcess.Create(request.Name, request.PeriodId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new ResponseDto(newEntity.Id);
    }
}
