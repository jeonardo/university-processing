using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Teachers;

internal sealed class Get : IEndpoint
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
            diplomaProcess => diplomaProcess.Teachers.Select(x => new TeacherDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.UniversityPosition.Name)),
            x => x
                .Include(d => d.Teachers)
                .ThenInclude(e => e.UniversityPosition),
            cancellationToken);

        return new ResponseDto(entity);
    }

    private sealed class RequestDto : BaseGetListQueryParameters
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }
    }

    private sealed class ResponseDto(PagedList<TeacherDto> pagedList) : PagedList<TeacherDto>(pagedList);

    private sealed class TeacherDto(Guid id, string firstName, string lastName, string? middleName, string position)
    {
        [Required]
        public Guid Id { get; set; } = id;

        [Required]
        public string FirstName { get; set; } = firstName;

        [Required]
        public string LastName { get; set; } = lastName;

        public string? MiddleName { get; set; } = middleName;

        [Required]
        public string Position { get; set; } = position;
    }
}
