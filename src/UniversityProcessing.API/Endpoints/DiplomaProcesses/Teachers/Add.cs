using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Teachers;

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
        [FromServices] IEfRepository<Teacher> teacherRepository,
        CancellationToken cancellationToken)
    {
        var diplomaProcess = await diplomaProcessRepository.GetByIdRequiredAsync(request.DiplomaProcessId, cancellationToken);
        var teacher = await teacherRepository.GetByIdRequiredAsync(request.UserId, cancellationToken);
        diplomaProcess.Teachers.Add(teacher);
        await diplomaProcessRepository.UpdateAsync(diplomaProcess, cancellationToken);
    }

    private sealed class RequestDto
    {
        [Required]
        public long DiplomaProcessId { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}
