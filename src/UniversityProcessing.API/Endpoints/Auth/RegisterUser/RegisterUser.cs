using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Auth.Common;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.API.Services.Registration;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.RegisterUser;

internal sealed class RegisterUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(RegisterUser);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin), nameof(UserRoleType.Deanery)))
            .AddEndpointFilter<ValidationFilter<RegisterUserRequestDto>>();
    }

    private static async Task Handle(
        HttpContext context,
        [FromBody] RegisterUserRequestDto request,
        [FromServices] IRegistrationService registrationService,
        [FromServices] ITokenService tokenService,
        CancellationToken cancellationToken)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);
        var selectedRole = ToDomainRole(request.Role);

        AuthCommon.ThrowIfRoleIsNotAllowed(claims.RoleType, selectedRole);

        await registrationService.Register(request, selectedRole, cancellationToken);
        await registrationService.Verify(request.UserName);
    }

    private static UserRoleType ToDomainRole(UserRoleDto roleType)
    {
        return roleType switch
        {
            UserRoleDto.Deanery => UserRoleType.Deanery,
            UserRoleDto.Admin => UserRoleType.Admin,
            UserRoleDto.Student => UserRoleType.Student,
            UserRoleDto.Teacher => UserRoleType.Teacher,
            _ => UserRoleType.None
        };
    }
}
