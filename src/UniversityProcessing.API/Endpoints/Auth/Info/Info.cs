using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.API.TODO.Endpoints.Converters;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Info;

internal sealed class Info : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Info);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static Task<InfoResponseDto> Handle(
        HttpContext context,
        [FromServices] ITokenService tokenService)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);
        return Task.FromResult(new InfoResponseDto(claims.UserId, claims.RoleType.ToDto(), claims.Approved));
    }
}
