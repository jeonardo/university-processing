using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;

namespace UniversityProcessing.DomainServices.Features.Identity.Login;

public sealed class LoginCommandHandler(
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

        var claims = await userManager.GetClaimsAsync(user);

        if (!claims.Any())
        {
            throw new ConflictException("User's claims not found");
        }

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken(claims);

        return new LoginCommandResponse(accessToken, refreshToken);
    }
}