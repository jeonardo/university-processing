using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Refresh;

internal sealed class Refresh : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Refresh);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RefreshRequestDto>>();
    }

    private async Task<RefreshResponseDto> Handle(
        [FromBody] RefreshRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ITokenService tokenService,
        [FromServices] IClaimService claimService,
        CancellationToken cancellationToken)
    {
        var claimsPrincipal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        var authTokenClaims = claimsPrincipal.GetAuthorizationTokenClaims();

        var user = await userManager.FindByIdAsync(authTokenClaims.UserId.ToString());

        if (user is null)
        {
            throw new NotFoundException($"{nameof(User)} not found");
        }

        if (user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiration < DateTime.UtcNow)
        {
            throw new InvalidTokenException();
        }

        var claims = await claimService.GetClaims(user);

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken(out _);

        return new RefreshResponseDto(accessToken, refreshToken);
    }
}
