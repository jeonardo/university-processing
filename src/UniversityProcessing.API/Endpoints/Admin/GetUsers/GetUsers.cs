using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Admin.GetUsers;

internal sealed class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(GetUsers), Handle)
            .WithTags(Tags.ADMIN)
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoles.ApplicationAdmin)))
            .AddEndpointFilter<ValidationFilter<GetUsersRequestDto>>();
    }

    private static async Task<GetUsersResponseDto> Handle(
        [AsParameters] GetUsersRequestDto request,
        [FromServices] IEfReadRepository<User> repository,
        CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new UserListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetUsersResponseDto(new PagedList<UserDto>(entities.Select(ToDto), count, request.PageNumber, request.PageSize));
    }

    private static UserDto ToDto(User user)
    {
        return new UserDto(user.Id, user.FirstName, user.LastName, user.MiddleName, user.Approved);
    }
}
