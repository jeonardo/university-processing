using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Converters;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.GenericSubdomain.Endpoints;

namespace UniversityProcessing.API.Endpoints.Identity.Info;

internal sealed class Info : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(nameof(Info), Handle)
            .WithTags(Tags.IDENTITY)
            .RequireAuthorization();
    }

    private static Task<InfoResponseDto> Handle(
        HttpContext context,
        [FromServices] ITokenService tokenService)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);
        return Task.FromResult(new InfoResponseDto(claims.UserId, claims.Roles.ToDto(), claims.Approved));
    }
}
