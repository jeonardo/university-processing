using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Faculties.SetFacultyHead;

internal sealed class SetFacultyHead : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(SetFacultyHead);
        app
            .MapPatch(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<SetFacultyHeadRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] SetFacultyHeadRequestDto request,
        [FromServices] IEfRepository<Faculty> facultyRepository,
        [FromServices] IEfRepository<User> userRepository,
        CancellationToken cancellationToken)
    {
        var faculty = await facultyRepository.TypedDbContext
                .AsNoTracking()
                .Include(x => x.Deaneries)
                .FirstOrDefaultAsync(x => x.Id == request.FacultyId, cancellationToken)
            ?? throw new NotFoundException("Faculty not found");

        if (!faculty.Deaneries.Any(x => x.Id == request.UserId && x.Role == UserRoleType.Deanery))
        {
            throw new AccessDeniedException("User does not exist or is not a deanery");
        }

        faculty.SetHead(request.UserId);

        await facultyRepository.UpdateAsync(faculty, cancellationToken);
    }
}
