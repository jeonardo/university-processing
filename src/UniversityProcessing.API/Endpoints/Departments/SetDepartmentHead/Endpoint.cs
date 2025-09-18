using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Departments.SetDepartmentHead;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapPatch(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfRepository<Department> departmentRepository,
        [FromServices] IEfRepository<User> userRepository,
        CancellationToken cancellationToken)
    {
        var department = await departmentRepository.TypedDbContext
                .AsNoTracking()
                .Include(x => x.Teachers)
                .FirstOrDefaultAsync(x => x.Id == request.DepartmentId, cancellationToken)
            ?? throw new NotFoundException("Department not found");

        if (!department.Teachers.Any(x => x.Id == request.UserId && x.Role == UserRoleType.Teacher))
        {
            throw new AccessDeniedException("User does not exist or is not a teacher");
        }

        department.SetHead(request.UserId);

        await departmentRepository.UpdateAsync(department, cancellationToken);
    }
}
