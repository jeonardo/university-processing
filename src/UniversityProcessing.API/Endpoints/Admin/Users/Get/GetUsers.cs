using Ardalis.Specification;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Admin.Users.Get;

internal sealed class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetUsers)), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<GetUsersRequestDto>>();
    }

    private static async Task<GetUsersResponseDto> Handle(
        [AsParameters] GetUsersRequestDto request,
        [FromServices] IEfReadRepository<User> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var specification = new GetGetUsersSpec(validRequest);
        var entities = await repository.ListAsync(specification, cancellationToken);

        var count = validRequest.IsFilterSet
            ? entities.Count
            : await repository.CountAsync(cancellationToken);

        return new GetUsersResponseDto(new PagedList<UserDto>(entities, count, validRequest.PageNumber, validRequest.PageSize));
    }

    private sealed class GetGetUsersSpec : Specification<User, UserDto>
    {
        public GetGetUsersSpec(GetListQueryParameters parameters)
        {
            Query
                .Select(x => new UserDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Approved))
                .AsNoTracking();

            if (string.IsNullOrWhiteSpace(parameters.Filter))
            {
                Query
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize);
            }
            else
            {
                Query
                    .Where(
                        x =>
                            x.FirstName.Contains(parameters.Filter)
                            || (x.MiddleName != null && x.MiddleName.Contains(parameters.Filter))
                            || x.LastName.Contains(parameters.Filter))
                    .Take(10);
            }
        }
    }
}
