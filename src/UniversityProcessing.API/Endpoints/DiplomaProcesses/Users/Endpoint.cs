using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Users;

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

    private static async Task Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> diplomaProcessRepository,
        [FromServices] IEfRepository<Teacher> teacherRepository,
        CancellationToken cancellationToken)
    {
        var diplomaProcess = await diplomaProcessRepository.GetByIdRequiredAsync(request.DiplomaProcessId, cancellationToken);
        var teacher = await teacherRepository.GetByIdRequiredAsync(request.UserId, cancellationToken);
        diplomaProcess.Teachers.Remove(teacher);
        await diplomaProcessRepository.UpdateAsync(diplomaProcess, cancellationToken);
    }

    private sealed class RequestDto
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
