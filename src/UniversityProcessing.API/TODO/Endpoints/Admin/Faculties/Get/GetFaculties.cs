using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Infrastructure.Interfaces.Specifications;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Faculties.Get;

internal sealed class GetFaculties : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetFaculties);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)));
    }

    private static async Task<GetFacultiesResponseDto> Handle(
        [AsParameters] GetFacultiesRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var specification = new GetFacultiesSpec(validRequest.PageNumber, validRequest.PageSize, validRequest.OrderBy, validRequest.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        var count = validRequest.IsFilterSet
            ? entities.Count
            : await repository.CountAsync(cancellationToken);

        return new GetFacultiesResponseDto(new PagedList<FacultyDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static FacultyDto ToDto(Faculty input)
    {
        return new FacultyDto(input.Id, input.Name, input.ShortName);
    }

    private sealed class GetFacultiesSpec(int pageNumber, int pageSize, string orderBy, bool desc)
        : BaseListSpec<Faculty>(pageNumber, pageSize, orderBy, desc)
    {
        protected override string[] AvailableProperties => ["id", "name", "short_name"];
    }
}
