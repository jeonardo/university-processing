using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Specialties.Delete;

internal sealed class DeleteSpecialty : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapDelete(NamespaceService.GetEndpointRoute(typeof(DeleteSpecialty)), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<DeleteSpecialtyRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteSpecialtyRequestDto request,
        [FromServices] IEfRepository<Specialty> repository,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        await repository.DeleteAsync(record, cancellationToken);
    }
}
