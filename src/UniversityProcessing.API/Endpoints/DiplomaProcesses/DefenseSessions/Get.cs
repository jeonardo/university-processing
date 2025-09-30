using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.DefenseSessions;

internal sealed class Get
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
        [FromServices] IEfReadRepository<DefenseSession> repository,
        CancellationToken cancellationToken)
    {
        var entity = await repository.TypedDbContext
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Include(d => d.Committee)
                .ThenInclude(d => d.Teachers)
                .Include(d => d.Students)
                .Select(
                    defenseSession => new ResponseDto(
                        defenseSession.Name,
                        defenseSession.Date,
                        new CommitteeDto(
                            defenseSession.Committee.Id,
                            defenseSession.Committee.Name,
                            defenseSession.Committee.Teachers.Select(x => new TeacherDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.UniversityPosition.Name))),
                        defenseSession.Students.Select(x => new StudentDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Group.Number))))
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException("Defense session not found");

        return entity;
    }

    private class RequestDto
    {
        [Required]
        public Guid Id { get; set; }
    }

    private sealed class ResponseDto(string name, DateTime date, CommitteeDto committee, IEnumerable<StudentDto> students)
    {
        [Required]
        public string Name { get; private set; } = name;

        [Required]
        public DateTime Date { get; private set; } = date;

        [Required]
        public CommitteeDto Committee { get; private set; } = committee;

        [Required]
        public IEnumerable<StudentDto> Students { get; private set; } = students;
    }

    private sealed class StudentDto(Guid id, string firstName, string lastName, string? middleName, string groupNumber)
    {
        [Required]
        public Guid Id { get; private set; } = id;

        [Required]
        public string FirstName { get; private set; } = firstName;

        [Required]
        public string LastName { get; private set; } = lastName;

        public string? MiddleName { get; private set; } = middleName;

        [Required]
        public string GroupNumber { get; private set; } = groupNumber;
    }

    private sealed class CommitteeDto(Guid id, string name, IEnumerable<TeacherDto> teachers)
    {
        [Required]
        public Guid Id { get; private set; } = id;

        [Required]
        public string Name { get; private set; } = name;

        [Required]
        public IEnumerable<TeacherDto> Teachers { get; private set; } = teachers;
    }

    private sealed class TeacherDto(Guid id, string firstName, string lastName, string? middleName, string position)
    {
        [Required]
        public Guid Id { get; private set; } = id;

        [Required]
        public string FirstName { get; private set; } = firstName;

        [Required]
        public string LastName { get; private set; } = lastName;

        public string? MiddleName { get; private set; } = middleName;

        [Required]
        public string Position { get; private set; } = position;
    }
}
