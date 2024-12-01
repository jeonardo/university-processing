using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Universities.Delete;
using UniversityProcessing.GenericSubdomain.Endpoints;

namespace UniversityProcessing.API.Endpoints.Admin.DeleteUniversity;

internal sealed class DeleteUniversity : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                nameof(DeleteUniversity),
                (
                    [FromBody] DeleteUniversityRequestDto request,
                    [FromServices] ISender sender,
                    CancellationToken cancellationToken) =>
                {
                    var command = new DeleteUniversityCommandRequest(request.Id);
                    return sender.Send(command, cancellationToken);
                })
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoles.ApplicationAdmin)));
    }
}
