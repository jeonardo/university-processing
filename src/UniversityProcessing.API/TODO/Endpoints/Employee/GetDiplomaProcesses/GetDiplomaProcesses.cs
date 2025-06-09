using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.GetDiplomaProcesses;

internal sealed class GetDiplomaProcesses : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetDiplomaProcesses);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireClaim(AppClaimTypes.IS_APPROVED, AppClaimTypes.BOOL_TRUE)); //TODO add to attribute and role check
    }

    private static async Task<GetDiplomaProcessesResponseDto> Handle(
        [AsParameters] GetDiplomaProcessesRequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var specification = new DiplomaPeriodListSpec(validRequest.PageNumber, validRequest.PageSize, validRequest.OrderBy, validRequest.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        var count = validRequest.IsFilterSet
            ? entities.Count
            : await repository.CountAsync(cancellationToken);

        return new GetDiplomaProcessesResponseDto(new PagedList<DiplomaProcessDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static DiplomaProcessDto ToDto(DiplomaProcess input)
    {
        return new DiplomaProcessDto(input.Id, input.Name);
    }
}
