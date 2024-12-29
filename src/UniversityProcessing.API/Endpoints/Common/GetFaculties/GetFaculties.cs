using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Common.GetFaculties;

internal sealed class GetFaculties : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetFaculties)), Handle)
            .RequireAuthorization();
    }

    private static async Task<GetFacultiesResponseDto> Handle(
        [AsParameters] GetFacultiesRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();
        var count = await repository.CountAsync(cancellationToken);

        var specification = new FacultyListSpec(validRequest.PageNumber, validRequest.PageSize, validRequest.OrderBy, validRequest.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetFacultiesResponseDto(new PagedList<FacultyDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static FacultyDto ToDto(Faculty input)
    {
        return new FacultyDto(input.Id, input.Name, input.ShortName);
    }
}
