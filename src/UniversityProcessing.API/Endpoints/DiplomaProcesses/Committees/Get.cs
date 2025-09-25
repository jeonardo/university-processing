using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Committees;

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
        [FromBody] RequestDto request,
        [FromServices] IEfReadRepository<Committee> repository,
        CancellationToken cancellationToken)
    {
        var committees = await repository.TypedDbContext.ToPagedListAsync(
            request,
            string.IsNullOrWhiteSpace(request.Filter)
                ? x => x.DiplomaProcessId == request.DiplomaProcessId
                : x => x.DiplomaProcessId == request.DiplomaProcessId && x.Name.Contains(request.Filter),
            x => new CommitteeDto(x.Id, x.Name, x.Teachers.Select(t => new TeacherDto(t.Id, t.FirstName, t.LastName, t.MiddleName, t.UniversityPosition.Name))),
            null,
            x => x
                .Include(d => d.Teachers)
                .ThenInclude(t => t.UniversityPosition),
            cancellationToken);

        return new ResponseDto(committees);
    }

    private sealed class RequestDto : BaseGetListQueryParameters
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }
    }

    private sealed class ResponseDto(PagedList<CommitteeDto> list) : PagedList<CommitteeDto>(list);

    private sealed class CommitteeDto(Guid id, string name, IEnumerable<TeacherDto> teachers)
    {
        [Required]
        public Guid Id { get; set; } = id;

        [Required]
        public string Name { get; set; } = name;

        [Required]
        public IEnumerable<TeacherDto> Teachers { get; set; } = teachers;
    }

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
