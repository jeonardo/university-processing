using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.ChangeAdmin;

internal sealed class ChangeUniversityAdmin : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPatch(nameof(ChangeUniversityAdmin), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoles.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<ChangeUniversityAdminRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] ChangeUniversityAdminRequestDto request,
        [FromServices] IEfRepository<University> repository,
        CancellationToken cancellationToken)
    {
        var university = await repository.GetByIdRequiredAsync(request.UniversityId, cancellationToken);

        university.Update(adminId: request.UserId);

        await repository.UpdateAsync(university, cancellationToken);
    }
}
