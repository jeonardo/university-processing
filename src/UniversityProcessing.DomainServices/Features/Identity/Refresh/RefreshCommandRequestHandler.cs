using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.Refresh;

internal sealed class RefreshCommandRequestHandler(
    UserManager<User> userManager,
    ITokenService tokenService) : IRequestHandler<RefreshCommandRequest, RefreshCommandResponse>
{
    public async Task<RefreshCommandResponse> Handle(RefreshCommandRequest request, CancellationToken cancellationToken)
    {
        var refreshClaims = tokenService.GetRefreshTokenClaims(request.RefreshToken);
        var userId = refreshClaims.UserId;

        var user = await userManager.FindByIdAsync(userId.ToString())
            ?? throw new InvalidTokenException();

        var claims = await userManager.GetClaimsAsync(user);

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken(claims);

        return new RefreshCommandResponse(accessToken, refreshToken);
    }
}
