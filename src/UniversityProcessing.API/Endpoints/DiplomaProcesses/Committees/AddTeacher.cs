using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Committees;

internal sealed class AddTeacher : IEndpoint
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
        [FromServices] IEfReadRepository<DiplomaProcess> diplomaProcessRepository,
        [FromServices] IEfRepository<Committee> committeeRepository,
        CancellationToken cancellationToken)
    {
        var diplomaProcess = await diplomaProcessRepository.TypedDbContext
            .AsNoTracking()
            .Where(x => x.Id == request.DiplomaProcessId)
            .Include(x => x.Teachers)
            .Include(x => x.Committees)
            .ThenInclude(x => x.Teachers)
            .FirstOrDefaultAsync(cancellationToken);

        if (diplomaProcess is null)
        {
            throw new NotFoundException("Diploma process not found");
        }

        var teacher = diplomaProcess.Teachers.FirstOrDefault(x => x.Id == request.UserId);

        if (teacher is null)
        {
            throw new NotFoundException("Teacher not found");
        }

        var committee = diplomaProcess.Committees.FirstOrDefault(x => x.Id == request.CommitteeId);

        if (committee is null)
        {
            throw new NotFoundException("Committee not found");
        }

        if (committee.Teachers.Any(x => x.Id == request.UserId))
        {
            throw new ConflictException("Teacher already added");
        }

        committee.Teachers.Add(teacher);

        await committeeRepository.UpdateAsync(committee, cancellationToken);
    }

    private sealed class RequestDto
    {
        [Required]
        public long DiplomaProcessId { get; set; }

        [Required]
        public long CommitteeId { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}
