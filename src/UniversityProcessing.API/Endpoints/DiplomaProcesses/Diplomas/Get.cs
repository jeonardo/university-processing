using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Diplomas;

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
        [FromServices] IEfReadRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var diplomasQuery = repository.TypedDbContext
            .AsNoTracking()
            .Where(x => x.DiplomaProcessId == request.DiplomaProcessId)
            .Include(group => group.Students)
            .ThenInclude(student => student.Diploma)
            .ThenInclude(diploma => diploma.Supervisor)
            .ThenInclude(supervisor => supervisor.UniversityPosition)
            .Include(group => group.Students)
            .ThenInclude(student => student.Diploma)
            .ThenInclude(diploma => diploma.Student)
            .ThenInclude(student => student.Group)
            .SelectMany(
                x => x.Students
                    .Where(student => student.Diploma != null)
                    .Select(
                        x => new DiplomaDto(
                            x.Diploma!.Id,
                            x.Diploma.Title,
                            x.Diploma.Status,
                            new StudentDto(
                                x.Diploma.Student.Id,
                                x.Diploma.Student.FirstName,
                                x.Diploma.Student.LastName,
                                x.Diploma.Student.MiddleName,
                                x.Diploma.Student.Group.Number),
                            x.Diploma.SupervisorId.HasValue
                                ? new TeacherDto(
                                    x.Diploma.Supervisor!.Id,
                                    x.Diploma.Supervisor.FirstName,
                                    x.Diploma.Supervisor.LastName,
                                    x.Diploma.Supervisor.MiddleName,
                                    x.Diploma.Supervisor.UniversityPosition.Name)
                                : null)))
            .AsQueryable();

        var diplomasCountTask = diplomasQuery.CountAsync(cancellationToken);
        var diplomasPaginatedTask = diplomasQuery
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToArrayAsync(cancellationToken);

        await Task.WhenAll(diplomasCountTask, diplomasPaginatedTask);

        return new ResponseDto(new PagedList<DiplomaDto>(diplomasPaginatedTask.Result, diplomasCountTask.Result, request.PageNumber, request.PageSize));
    }

    private class RequestDto : BaseGetListQueryParameters
    {
        [Required]
        public Guid DiplomaProcessId { get; set; }
    }

    private sealed class ResponseDto(PagedList<DiplomaDto> list) : PagedList<DiplomaDto>(list);

    private sealed class DiplomaDto(Guid id, string? title, DiplomaStatus status, StudentDto student, TeacherDto? supervisor)
    {
        [Required]
        public Guid Id { get; set; } = id;

        public string? Title { get; set; } = title;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DiplomaStatus Status { get; set; } = status;

        [Required]
        public StudentDto Student { get; set; } = student;

        public TeacherDto? Supervisor { get; set; } = supervisor;
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

    private sealed class StudentDto(Guid id, string firstName, string lastName, string? middleName, string groupNumber)
    {
        [Required]
        public Guid Id { get; set; } = id;

        [Required]
        public string FirstName { get; set; } = firstName;

        [Required]
        public string LastName { get; set; } = lastName;

        public string? MiddleName { get; set; } = middleName;

        [Required]
        public string GroupNumber { get; set; } = groupNumber;
    }
}
