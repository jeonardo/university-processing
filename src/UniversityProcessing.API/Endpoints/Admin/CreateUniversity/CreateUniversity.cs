using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Universities.Create;
using UniversityProcessing.GenericSubdomain.Endpoints;

namespace UniversityProcessing.API.Endpoints.Admin.CreateUniversity;

internal sealed class CreateUniversity : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                nameof(CreateUniversity),
                async (
                    [FromBody] CreateUniversityRequestDto request,
                    [FromServices] ISender sender,
                    CancellationToken cancellationToken) =>
                {
                    var command = new CreateUniversityCommandRequest(request.Name, request.ShortName);
                    var response = await sender.Send(command, cancellationToken);
                    return new CreateUniversityResponseDto(response.Id);
                })
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoles.ApplicationAdmin)));
    }
}
