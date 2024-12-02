using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Groups.Create;

internal sealed class CreateGroup : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(nameof(CreateGroup), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoles.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<CreateGroupRequestDto>>();
    }

    private static async Task<CreateGroupResponseDto> Handle(
        [FromBody] CreateGroupRequestDto request,
        [FromServices] IEfRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Group.Create(request.GroupNumber, request.StartDate, request.EndDate, request.SpecialtyId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateGroupResponseDto(newEntity.Id);
    }
}
