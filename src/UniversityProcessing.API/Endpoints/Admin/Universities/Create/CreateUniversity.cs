using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.Create;

internal sealed class CreateUniversity : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(NamespaceService.GetEndpointRoute(typeof(CreateUniversity)), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<CreateUniversityRequestDto>>();
    }

    private static async Task<CreateUniversityResponseDto> Handle(
        [FromBody] CreateUniversityRequestDto request,
        [FromServices] IEfRepository<University> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = University.Create(request.Name, request.ShortName, request.AdminId);

        var createdEntity = await repository.AddAsync(newEntity, cancellationToken);

        return new CreateUniversityResponseDto(createdEntity.Id);
    }
}
