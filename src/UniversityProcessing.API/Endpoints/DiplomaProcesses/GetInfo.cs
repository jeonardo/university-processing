using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses;

internal sealed class GetInfo : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfReadRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var responseDto = await repository.TypedDbContext
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Include(d => d.Teachers)
                .ThenInclude(e => e.ProjectTitles)
                .Include(x => x.RequiredProjectTitles)
                .Select(
                    x => new ResponseDto(
                        x.Id,
                        x.Name,
                        x.PossibleFrom,
                        x.PossibleTo,
                        x.RequiredProjectTitles
                            .Select(p => new ProjectTitleDto(p.Id, p.Title, p.CreatorId, p.ActorId))
                            .ToArray(),
                        x.Teachers
                            .SelectMany(teacher => teacher.ProjectTitles.Select(p => new ProjectTitleDto(p.Id, p.Title, p.CreatorId, p.ActorId)))
                            .ToArray()))
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException("Diploma process not found");

        return responseDto;
    }

    private sealed class RequestDto
    {
        public Guid Id { get; set; }
    }

    private sealed class ResponseDto(
        Guid id,
        string name,
        DateTime? possibleFrom,
        DateTime? possibleTo,
        ICollection<ProjectTitleDto> requiredProjectTitles,
        ICollection<ProjectTitleDto> optionalProjectTitles)
    {
        public Guid Id { get; init; } = id;
        public string Name { get; init; } = name;
        public DateTime? PossibleFrom { get; init; } = possibleFrom;
        public DateTime? PossibleTo { get; init; } = possibleTo;
        public ICollection<ProjectTitleDto> RequiredProjectTitles { get; init; } = requiredProjectTitles;
        public ICollection<ProjectTitleDto> OptionalProjectTitles { get; init; } = optionalProjectTitles;
    }

    private sealed class ProjectTitleDto(Guid id, string title, Guid creatorId, Guid? actorId)
    {
        public Guid Id { get; init; } = id;
        public string Title { get; set; } = title;

        public Guid CreatorId { get; set; } = creatorId;

        public Guid? ActorId { get; set; } = actorId;
    }
}
