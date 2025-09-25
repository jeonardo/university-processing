using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Committees;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfRepository<Committee> committeeRepository,
        CancellationToken cancellationToken)
    {
        var committee = Committee.Create(request.DiplomaProcessId, request.Name);
        await committeeRepository.AddAsync(committee, cancellationToken);
    }

    private sealed class RequestDto
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
