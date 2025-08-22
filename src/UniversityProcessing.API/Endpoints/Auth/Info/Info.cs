using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Info;

internal sealed class Info : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Info);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<InfoResponseDto> Handle(
        HttpContext context,
        [FromServices] IEfRepository<User> repository,
        [FromServices] ITokenService tokenService,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        var claims = context.User.GetAuthorizationTokenClaims();
        var user = await repository.GetByIdRequiredAsync(claims.UserId, cancellationToken);
        var roles = await userManager.GetRolesAsync(user);
        return
            new InfoResponseDto(
                user.Id,
                roles.Select(x => Enum.TryParse<UserRoleTypeDto>(x, out var role) ? role : UserRoleTypeDto.None).ToArray(),
                user.Approved,
                user.Blocked,
                user.FirstName,
                user.LastName,
                user.MiddleName);
    }
}
