using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Committees;

internal sealed class GetFreeTeachers
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<ResponseDto> Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfReadRepository<DiplomaProcess> diplomaProcessRepository,
        [FromServices] IEfRepository<Committee> committeeRepository,
        CancellationToken cancellationToken)
    {
        var diplomaProcess = await diplomaProcessRepository.TypedDbContext
            .AsNoTracking()
            .Where(x => x.Id == request.DiplomaProcessId)
            .Include(x => x.Teachers)
            .ThenInclude(x => x.UniversityPosition)
            .Include(x => x.Committees)
            .ThenInclude(x => x.Teachers)
            .FirstOrDefaultAsync(cancellationToken);

        if (diplomaProcess is null)
        {
            throw new NotFoundException("Diploma process not found");
        }

        var busyTeachers = diplomaProcess.Committees.SelectMany(x => x.Teachers.Select(teacher => teacher.Id)).ToHashSet();
        var allTeachers = diplomaProcess.Teachers;

        var freeTeachers = allTeachers
            .Where(x => !busyTeachers.Contains(x.Id))
            .ToArray();

        var freeTeachersPaginated = freeTeachers
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new TeacherDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.UniversityPosition.Name))
            .ToArray();

        return new ResponseDto(new PagedList<TeacherDto>(freeTeachersPaginated, freeTeachers.Length, request.PageSize, request.PageSize));
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
