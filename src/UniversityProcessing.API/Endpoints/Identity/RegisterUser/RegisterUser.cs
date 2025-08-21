using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Identity.RegisterUser;

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

        UserAccessManager.ThrowIfRoleIsNotAllowed(claims.RoleType, selectedRole);

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
