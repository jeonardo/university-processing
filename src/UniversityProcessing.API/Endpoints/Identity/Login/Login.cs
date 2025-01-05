using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Converters;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.GenericSubdomain.Namespace;

namespace UniversityProcessing.API.Endpoints.Identity.Login;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(NamespaceService.GetEndpointRoute(typeof(Login)), Handle)
            .WithTags(Tags.IDENTITY)
            .AddEndpointFilter<ValidationFilter<LoginRequestDto>>();
    }

    private static async Task<LoginResponseDto> Handle(
        [FromBody] LoginRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] SignInManager<User> signInManager,
        [FromServices] ITokenService tokenService,
        CancellationToken cancellationToken)
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
            const string errorMessage = "Invalid password";
            throw new ConflictException(errorMessage);
        }

        var userRoles = await userManager.GetRolesAsync(user);

        var claims = GetDefaultClaims(user, userRoles);
        var additionalClaims = await userManager.GetClaimsAsync(user);
        claims.AddRange(additionalClaims);

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken(claims);

        return new LoginResponseDto(TokenConverter.ToDto(accessToken), TokenConverter.ToDto(refreshToken));
    }

    private static List<Claim> GetDefaultClaims(User user, IEnumerable<string> roles)
    {
        var list = new List<Claim>
        {
            new(AppClaimTypes.USER_ID, user.Id.ToString()),
            new(AppClaimTypes.IS_APPROVED, user.Approved.ToString())
        };

        list.AddRange(roles.Select(role => new Claim(AppClaimTypes.ROLE, role)));

        return list;
    }
}
