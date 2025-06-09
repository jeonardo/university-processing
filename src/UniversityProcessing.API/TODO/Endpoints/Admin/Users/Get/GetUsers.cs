using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Users.Get;

internal sealed class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetUsers);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)));
    }

    private static async Task<GetUsersResponseDto> Handle(
        [AsParameters] GetUsersRequestDto request,
        [FromServices] IEfReadRepository<User> repository,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var entities = await userManager.GetUsersInRoleAsync(nameof(UserRoleType.Admin));

        User[] filteredEntities;

        if (string.IsNullOrWhiteSpace(validRequest.Filter))
        {
            filteredEntities = entities
                .Skip((validRequest.PageNumber - 1) * validRequest.PageSize)
                .Take(validRequest.PageSize)
                .ToArray();
        }
        else
        {
            filteredEntities = entities
                .Where(
                    x =>
                        x.FirstName.Contains(validRequest.Filter)
                        || (x.MiddleName != null && x.MiddleName.Contains(validRequest.Filter))
                        || x.LastName.Contains(validRequest.Filter))
                .Take(validRequest.PageSize)
                .ToArray();
        }

        var count = validRequest.IsFilterSet
            ? filteredEntities.Length
            : entities.Count;

        return new GetUsersResponseDto(new PagedList<UserDto>(filteredEntities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static UserDto ToDto(User input)
    {
        return new UserDto(input.Id, input.FirstName, input.LastName, input.MiddleName, input.Approved);
    }
}
