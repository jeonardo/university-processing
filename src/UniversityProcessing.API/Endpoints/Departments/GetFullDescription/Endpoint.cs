using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var faculty = await repository.TypedDbContext
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Include(x => x.Teachers)
                .ThenInclude(x => x.UniversityPosition)
                .SingleOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException("Department not found");

        UserDto? head = null;
        var teachers = new List<UserDto>();

        foreach (var teacher in faculty.Teachers)
        {
            if (faculty.HeadUserId.HasValue && faculty.HeadUserId.Value == teacher.Id)
            {
                head = new UserDto(
                    teacher.Id,
                    teacher.FirstName,
                    teacher.LastName,
                    teacher.MiddleName,
                    teacher.Email,
                    teacher.PhoneNumber,
                    teacher.UniversityPosition.Name,
                    teacher.Blocked,
                    teacher.Approved);
            }

            teachers.Add(
                new UserDto(
                    teacher.Id,
                    teacher.FirstName,
                    teacher.LastName,
                    teacher.MiddleName,
                    teacher.Email,
                    teacher.PhoneNumber,
                    teacher.UniversityPosition.Name,
                    teacher.Blocked,
                    teacher.Approved));
        }

        return new ResponseDto(faculty.Id, faculty.Name, faculty.ShortName, head, teachers);
    }
}
