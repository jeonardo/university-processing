using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Common.GetDiplomaPeriods;

internal sealed class GetDiplomaPeriods : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetDiplomaPeriods)), Handle)
            .RequireAuthorization(x => x.RequireClaim(AppClaimTypes.IS_APPROVED, AppClaimTypes.BOOL_TRUE)); //TODO add to attribute and role check
    }

    private static async Task<GetDiplomaPeriodsResponseDto> Handle(
        [AsParameters] GetDiplomaPeriodsRequestDto request,
        [FromServices] IEfRepository<DiplomaPeriod> repository,
        CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new DiplomaPeriodListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetDiplomaPeriodsResponseDto(new PagedList<DiplomaPeriodDto>(entities.Select(ToDto), count, request.PageNumber, request.PageSize));
    }

    private static DiplomaPeriodDto ToDto(DiplomaPeriod input)
    {
        return new DiplomaPeriodDto(input.Id, input.Name, input.StudyPeriodFrom, input.StudyPeriodTo);
    }
}
