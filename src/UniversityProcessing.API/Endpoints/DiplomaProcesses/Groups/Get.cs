using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Groups;

internal sealed class GetFullDescription : IEndpoint
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
        [FromBody] RequestDto request,
        [FromServices] IEfReadRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext
            .ToPagedListAsync(
                request,
                x =>
                    x.Id == request.DiplomaProcessId
                    && (request.Filter == null || x.Name.Contains(request.Filter)), //what name
                null,
                x => x.Groups.Select(g => new GroupDto(g.Id, g.Number)),
                x => x.Include(d => d.Groups),
                cancellationToken);

        return new ResponseDto(pagedList);
    }

    private sealed class RequestDto : BaseGetListQueryParameters
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }
    }

    private sealed class ResponseDto(PagedList<GroupDto> list) : PagedList<GroupDto>(list);

    private sealed class GroupDto(Guid id, string number)
    {
        public Guid Id { get; set; } = id;
        public string Number { get; set; } = number;
    }
}
