using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Faculties.Delete;

internal sealed class DeleteFaculty : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeleteFaculty);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteFacultyRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteFacultyRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var record = await repository.TypedDbContext
                .AsNoTracking()
                .Include(x => x.Departments)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Faculty not found");

        if (record.Departments.Count != 0)
        {
            throw new ConflictException("Faculty contains departments");
        }

        await repository.DeleteAsync(record, cancellationToken);
    }
}
