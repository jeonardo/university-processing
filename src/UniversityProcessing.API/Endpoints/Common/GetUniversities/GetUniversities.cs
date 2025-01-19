using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Common.GetUniversities;

internal sealed class GetUniversities : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetUniversities)), Handle)
            .WithTags(Tags.COMMON)
            .RequireAuthorization();
    }

    private static async Task<GetUniversitiesResponseDto> Handle(
        [AsParameters] GetUniversitiesRequestDto request,
        [FromServices] IEfReadRepository<University> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var specification = new UniversityListSpec(validRequest.PageNumber, validRequest.PageSize, validRequest.OrderBy, validRequest.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        var count = validRequest.IsFilterSet
            ? entities.Count
            : await repository.CountAsync(cancellationToken);

        return new GetUniversitiesResponseDto(new PagedList<UniversityDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static UniversityDto ToDto(University input)
    {
        return new UniversityDto(input.Id, input.Name, input.ShortName);
    }
}
