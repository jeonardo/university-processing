using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.DefenseSessions;

internal sealed class GetFreeStudents : IEndpoint
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
        var students = await repository.TypedDbContext
            .AsNoTracking()
            .Where(x => x.Id == request.DiplomaProcessId)
            .Include(x => x.Students)
            .ThenInclude(x => x.Group)
            .SelectMany(x => x.Students.Select(x => new StudentDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Group.Number)))
            .ToArrayAsync(cancellationToken);

        return new ResponseDto(students);
    }

    private sealed class RequestDto
    {
        [Required]
        public long DiplomaProcessId { get; set; }
    }

    private sealed class ResponseDto(IEnumerable<StudentDto> students)
    {
        [Required]
        public IEnumerable<StudentDto> Students { get; set; } = students;
    }

    private sealed class StudentDto(long id, string firstName, string lastName, string? middleName, string groupNumber)
    {
        [Required]
        public long Id { get; private set; } = id;

        [Required]
        public string FirstName { get; private set; } = firstName;

        [Required]
        public string LastName { get; private set; } = lastName;

        public string? MiddleName { get; private set; } = middleName;

        [Required]
        public string GroupNumber { get; private set; } = groupNumber;
    }
}
