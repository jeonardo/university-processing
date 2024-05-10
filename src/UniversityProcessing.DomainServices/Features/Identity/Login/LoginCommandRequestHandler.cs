using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;
using UniversityProcessing.GenericSubdomain.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.Login;

internal sealed class LoginCommandHandler(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService)
    : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName)
            ?? throw new NotFoundException($"User with username = {request.UserName} not found");

        var signInResult = await signInManager.PasswordSignInAsync(
            user,
            request.Password,
            false,
            false);

        if (!signInResult.Succeeded)
        {
            throw new ConflictException(signInResult.ToString());
        }

        var userRoles = await userManager.GetRolesAsync(user);

        var claims = GetDefaultClaims(user, userRoles.First());
        var additionalClaims = await userManager.GetClaimsAsync(user);
        claims.AddRange(additionalClaims);

        var accessToken = tokenService.GenerateAccessToken(additionalClaims);
        var refreshToken = tokenService.GenerateRefreshToken(additionalClaims);

        return new LoginCommandResponse(accessToken, refreshToken);
    }

    private List<Claim> GetDefaultClaims(User user, string role)
    {
        return
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim(nameof(user.Approved), user.Approved.ToString())
        ];
    }
}