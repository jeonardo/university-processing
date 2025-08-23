using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Endpoints.Converters;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Login;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Login);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
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

        if (signInResult.IsFailed())
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
            new(AppClaimTypes.IS_APPROVED, user.Approved.ToString()),
            new(AppClaimTypes.IS_BLOCKED, user.Blocked.ToString())
        };

        list.AddRange(roles.Select(role => new Claim(AppClaimTypes.ROLE, role)));

        return list;
    }
}
