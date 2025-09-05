using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

internal sealed class GetDepartmentFullDescription : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetDepartmentFullDescription);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Deanery)))
            .AddEndpointFilter<ValidationFilter<GetDepartmentFullDescriptionRequestDto>>();
    }

    private static async Task<GetDepartmentFullDescriptionResponseDto> Handle(
        [AsParameters] GetDepartmentFullDescriptionRequestDto request,
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

        DepartmentFullDescriptionUserDto? head = null;
        var teachers = new List<DepartmentFullDescriptionUserDto>();

        foreach (var teacher in faculty.Teachers)
        {
            if (faculty.HeadUserId.HasValue && faculty.HeadUserId.Value == teacher.Id)
            {
                head = new DepartmentFullDescriptionUserDto(
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
                new DepartmentFullDescriptionUserDto(
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

        return new GetDepartmentFullDescriptionResponseDto(faculty.Id, faculty.Name, faculty.ShortName, head, teachers);
    }
}
