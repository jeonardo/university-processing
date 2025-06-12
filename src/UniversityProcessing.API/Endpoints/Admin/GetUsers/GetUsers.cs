using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure;

namespace UniversityProcessing.API.Endpoints.Admin.GetUsers;

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
        [FromServices] ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var roles = await context.Roles
            .Where(x => x.Name == nameof(UserRoleType.Admin) || x.Name == nameof(UserRoleType.Deanery))
            .ToArrayAsync(cancellationToken);

        var users = Array.Empty<User>();
        var totalCount = 0;

        if (roles.Length != 0)
        {
            var query =
                from userRole in context.UserRoles
                join user in context.Users on userRole.UserId equals user.Id
                where
                    (userRole.RoleId == roles[0].Id || userRole.RoleId == roles[1].Id)
                    && (string.IsNullOrEmpty(validRequest.Filter)
                        || user.FirstName.Contains(validRequest.Filter)
                        || (user.MiddleName != null && user.MiddleName.Contains(validRequest.Filter))
                        || user.LastName.Contains(validRequest.Filter))
                select user;

            totalCount = await query.CountAsync(cancellationToken);

            users = await query
                .Skip((validRequest.PageNumber - 1) * validRequest.PageSize)
                .Take(validRequest.PageSize)
                .ToArrayAsync(cancellationToken);
        }

        return new GetUsersResponseDto(new PagedList<UserDto>(users.Select(ToDto), totalCount, validRequest.PageNumber, validRequest.PageSize));
    }

    private static UserDto ToDto(User input)
    {
        return new UserDto(input.Id, input.FirstName, input.LastName, input.MiddleName, input.Approved);
    }
}
