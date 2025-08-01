using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

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
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);
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
