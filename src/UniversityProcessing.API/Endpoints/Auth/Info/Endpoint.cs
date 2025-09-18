using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Endpoints.Converters;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.API.Endpoints.Auth.Info;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<ResponseDto> Handle(
        [FromServices] IHttpContextAccessor contextAccessor,
        [FromServices] IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
    {
        var claims = contextAccessor.HttpContext!.User.GetAuthorizationTokenClaims();

        switch (claims.Role)
        {
            case UserRoleType.Admin:
                var admin = await serviceProvider
                    .GetRequiredService<IEfReadRepository<Admin>>()
                    .TypedDbContext
                    .AsNoTracking()
                    .Where(x => x.Id == claims.UserId)
                    .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Admin not found");
                return new ResponseDto(
                    claims.UserId,
                    claims.Role.ToDto(),
                    claims.Approved,
                    claims.Blocked,
                    admin.FirstName,
                    admin.LastName,
                    admin.MiddleName,
                    admin.UserName,
                    null,
                    null,
                    admin.Email,
                    null,
                    admin.PhoneNumber,
                    null,
                    null,
                    null,
                    null);

            case UserRoleType.Deanery:
                var deanery = await serviceProvider
                    .GetRequiredService<IEfReadRepository<Deanery>>()
                    .TypedDbContext
                    .AsNoTracking()
                    .Where(x => x.Id == claims.UserId)
                    .Include(x => x.Faculty)
                    .Include(x => x.UniversityPosition)
                    .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Deanery not found");
                return new ResponseDto(
                    claims.UserId,
                    claims.Role.ToDto(),
                    claims.Approved,
                    claims.Blocked,
                    deanery.FirstName,
                    deanery.LastName,
                    deanery.MiddleName,
                    deanery.UserName,
                    deanery.Faculty.Name,
                    null,
                    deanery.Email,
                    deanery.UniversityPosition.Name,
                    deanery.PhoneNumber,
                    null,
                    null,
                    deanery.FacultyId,
                    null);

            case UserRoleType.Teacher:
                var teacher = await serviceProvider.GetRequiredService<IEfReadRepository<Teacher>>()
                        .TypedDbContext
                        .AsNoTracking()
                        .Where(x => x.Id == claims.UserId)
                        .Include(x => x.Department)
                        .ThenInclude(x => x.Faculty)
                        .Include(x => x.UniversityPosition)
                        .FirstOrDefaultAsync(cancellationToken)
                    ?? throw new NotFoundException("Teacher not found");
                return new ResponseDto(
                    claims.UserId,
                    claims.Role.ToDto(),
                    claims.Approved,
                    claims.Blocked,
                    teacher.FirstName,
                    teacher.LastName,
                    teacher.MiddleName,
                    teacher.UserName,
                    teacher.Department.Faculty.Name,
                    teacher.Department.Name,
                    teacher.Email,
                    teacher.UniversityPosition.Name,
                    teacher.PhoneNumber,
                    null,
                    null,
                    teacher.Department.FacultyId,
                    teacher.DepartmentId,
                    teacher.Department.HeadUserId == teacher.Id);

            case UserRoleType.Student:
                var student = await serviceProvider.GetRequiredService<IEfReadRepository<Student>>()
                        .TypedDbContext
                        .AsNoTracking()
                        .Where(x => x.Id == claims.UserId)
                        .Include(x => x.Group)
                        .ThenInclude(x => x.Specialty)
                        .ThenInclude(x => x.Department)
                        .ThenInclude(x => x.Faculty)
                        .FirstOrDefaultAsync(cancellationToken)
                    ?? throw new NotFoundException("Student not found");
                return new ResponseDto(
                    claims.UserId,
                    claims.Role.ToDto(),
                    claims.Approved,
                    claims.Blocked,
                    student.FirstName,
                    student.LastName,
                    student.MiddleName,
                    student.UserName,
                    student.Group.Specialty.Department.Faculty.Name,
                    student.Group.Specialty.Department.Name,
                    student.Email,
                    null,
                    student.PhoneNumber,
                    student.Group.Specialty.Name,
                    student.Group.Number,
                    student.Group.Specialty.Department.FacultyId,
                    student.Group.Specialty.DepartmentId);

            default:
                throw new NotFoundException("User not found");
        }
    }
}
