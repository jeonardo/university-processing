using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.DefenseSessions;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private async Task<ResponseDto> Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfReadRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
    }

    private class ResponseDto
    {
    }

    private class RequestDto
    {
    }
}
