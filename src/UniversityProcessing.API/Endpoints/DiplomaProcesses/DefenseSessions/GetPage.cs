using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.DefenseSessions;

internal sealed class GetPage : IEndpoint
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
        var entity = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => x.Id == request.DiplomaProcessId,
            null,
            diplomaProcess => diplomaProcess.DefenseSessions.Select(x => new DefenseSessionDto(x.Id, x.Date, x.Committee.Name)),
            x => x
                .Include(d => d.DefenseSessions)
                .ThenInclude(e => e.Committee),
            cancellationToken);

        return new ResponseDto(entity);
    }

    private sealed class RequestDto : BaseGetListQueryParameters
    {
        [Required]
        public long DiplomaProcessId { get; private set; }
    }

    private sealed class ResponseDto(PagedList<DefenseSessionDto> pagedList) : PagedList<DefenseSessionDto>(pagedList);

    private sealed class DefenseSessionDto(long id, DateTime date, string committeeName)
    {
        [Required]
        public long Id { get; private set; } = id;

        [Required]
        public DateTime Date { get; private set; } = date;

        [Required]
        public string CommitteeName { get; private set; } = committeeName;
    }
}
