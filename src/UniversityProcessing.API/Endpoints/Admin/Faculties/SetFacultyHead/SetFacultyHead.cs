using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Faculties.SetFacultyHead;

internal sealed class SetFacultyHead : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(SetFacultyHead);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<SetFacultyHeadRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] SetFacultyHeadRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var faculty = await repository.GetByIdRequiredAsync(request.FacultyId, cancellationToken);

        faculty.SetHead(request.UserId);

        await repository.UpdateAsync(faculty, cancellationToken);
    }
}
