using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;

namespace UniversityProcessing.API.Endpoints.Auth.Login;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [FromBody] RequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] SignInManager<User> signInManager,
        [FromServices] ITokenService tokenService,
        [FromServices] IClaimService claimService,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName)
            ?? throw new NotFoundException($"User with username = {request.UserName} not found");

        var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if (signInResult.IsFailed())
        {
            const string errorMessage = "Invalid password";
            throw new ConflictException(errorMessage);
        }

        var claims = await claimService.GetClaims(user);

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken(out var expirationTime);

        user.UpdateRefreshToken(refreshToken, expirationTime);
        await userManager.UpdateAsync(user);

        return new ResponseDto(accessToken, refreshToken);
    }
}
