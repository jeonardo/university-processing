using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
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
        [FromServices] IEfReadRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext
            .ToPagedListAsync(
                request,
                x =>
                    x.DiplomaProcessId == request.DiplomaProcessId
                    && (request.Filter == null || x.Number.Contains(request.Filter)),
                g => new GroupDto(g.Id, g.Number),
                null,
                null,
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
