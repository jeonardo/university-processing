using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Converters;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.GenericSubdomain.Namespace;

namespace UniversityProcessing.API.Endpoints.Identity.Refresh;

internal sealed class Refresh : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(Refresh)), Handle)
            .WithTags(Tags.IDENTITY)
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
