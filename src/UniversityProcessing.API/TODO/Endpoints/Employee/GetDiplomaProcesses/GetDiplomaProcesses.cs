using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Converters;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

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
        var entities = await repository.TypedDbContext.ToPagedListAsync(request, null, cancellationToken);
        return new GetDiplomaProcessesResponseDto(PagedListConverter.Convert(entities, ToDto));
    }

    private static DiplomaProcessDto ToDto(DiplomaProcess input)
    {
        return new DiplomaProcessDto(input.Id, input.Name);
    }
}
