using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Common.GetSpecialties;

internal sealed class GetSpecialties : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetSpecialties)), Handle)
            .WithTags(Tags.COMMON)
            .RequireAuthorization();
    }

    private static async Task<GetSpecialtiesResponseDto> Handle(
        [AsParameters] GetSpecialtiesRequestDto request,
        [FromServices] IEfReadRepository<Specialty> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();
        var count = await repository.CountAsync(cancellationToken);

        var specification = new SpecialtyListSpec(validRequest.PageNumber, validRequest.PageSize, validRequest.OrderBy, validRequest.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetSpecialtiesResponseDto(new PagedList<SpecialtyDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static SpecialtyDto ToDto(Specialty input)
    {
        return new SpecialtyDto(input.Id, input.Name, input.ShortName, input.Code);
    }
}
