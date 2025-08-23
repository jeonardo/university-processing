using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Endpoints.Converters;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Refresh;

internal sealed class Refresh : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Refresh);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private async Task<RefreshResponseDto> Handle(
        HttpContext context,
        [FromServices] UserManager<User> userManager,
        [FromServices] ITokenService tokenService,
        CancellationToken cancellationToken)
    {
        var refreshClaims = tokenService.GetRefreshTokenClaims(context.Request.Headers.Authorization.ToString());
        var userId = refreshClaims.UserId;

        var user = await userManager.FindByIdAsync(userId.ToString())
            ?? throw new InvalidTokenException();

        var claims = await userManager.GetClaimsAsync(user);

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken(claims);

        return new RefreshResponseDto(TokenConverter.ToDto(accessToken), TokenConverter.ToDto(refreshToken));
    }
}
