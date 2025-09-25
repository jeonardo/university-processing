using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Groups;

internal sealed class Add : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapPut(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> diplomaProcessRepository,
        [FromServices] IEfRepository<Group> groupRepository,
        CancellationToken cancellationToken)
    {
        var diplomaProcess = await diplomaProcessRepository.GetByIdRequiredAsync(request.DiplomaProcessId, cancellationToken);
        var group = await groupRepository.GetByIdRequiredAsync(request.GroupId, cancellationToken);
        diplomaProcess.AddGroup(group);
        await diplomaProcessRepository.UpdateAsync(diplomaProcess, cancellationToken);
    }

    private sealed class RequestDto
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }

        [Required]
        public Guid GroupId { get; set; }
    }
}
