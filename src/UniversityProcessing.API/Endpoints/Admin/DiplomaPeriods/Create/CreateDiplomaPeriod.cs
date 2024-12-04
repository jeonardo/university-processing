using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Create;

internal sealed class CreateDiplomaPeriod : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(nameof(CreateDiplomaPeriod), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<CreateDiplomaPeriodRequestDto>>();
    }

    private static async Task<CreateDiplomaPeriodResponseDto> Handle(
        [FromBody] CreateDiplomaPeriodRequestDto request,
        [FromServices] IEfRepository<DiplomaPeriod> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = DiplomaPeriod.Create(request.StartDate, request.EndDate, request.FacultyId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateDiplomaPeriodResponseDto(newEntity.Id);
    }
}
