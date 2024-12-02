using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Common.GetGroups;

internal sealed class GetGroups : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(GetGroups), Handle)
            .RequireAuthorization();
    }

    private static async Task<GetGroupsResponseDto> Handle(
        [AsParameters] GetGroupsRequestDto request,
        [FromServices] IEfReadRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new GroupListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetGroupsResponseDto(new PagedList<GroupDto>(entities.Select(ToDto), count, request.PageNumber, request.PageSize));
    }

    private static GroupDto ToDto(Group input)
    {
        return new GroupDto(input.Id, input.Number);
    }
}
