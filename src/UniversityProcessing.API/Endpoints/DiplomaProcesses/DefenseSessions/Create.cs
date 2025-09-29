using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.DefenseSessions;

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

    private async Task Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfRepository<DefenseSession> defenseSessionRepository,
        [FromServices] IEfRepository<Student> studentRepository,
        CancellationToken cancellationToken)
    {
        var defenseSession = DefenseSession.Create(
            request.CommitteeId,
            request.Name,
            request.DiplomaProcessId,
            request.Date);

        await defenseSessionRepository.AddAsync(defenseSession, cancellationToken);

        var students = await studentRepository.TypedDbContext
            .Where(x => request.StudentIds.Contains(x.Id) && x.DefenseSessionId == null)
            .ToArrayAsync(cancellationToken);

        foreach (var student in students)
        {
            student.SetSession(defenseSession.Id);
        }

        await studentRepository.UpdateRangeAsync(students, cancellationToken);
    }

    private class RequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CommitteeId { get; set; }

        [Required]
        public Guid DiplomaProcessId { get; set; }

        [Required]
        public Guid[] StudentIds { get; set; } = Array.Empty<Guid>();
    }
}
