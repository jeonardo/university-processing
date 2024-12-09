using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Groups.Delete;

internal sealed class DeleteGroup : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapDelete(nameof(DeleteGroup), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<DeleteGroupRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteGroupRequestDto request,
        [FromServices] IEfRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        await repository.DeleteAsync(record, cancellationToken);
    }
}
