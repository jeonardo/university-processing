using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Services.Registration;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register;

internal sealed class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Register);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RegisterRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RegisterRequestDto request,
        [FromServices] IRegistrationService registrationService,
        CancellationToken cancellationToken)
    {
        await registrationService.Register(request, ToDomainRole(request.Role), cancellationToken);
    }

    private static UserRoleType ToDomainRole(UserRoleDto roleType)
    {
        return roleType switch
        {
            UserRoleDto.Deanery => UserRoleType.Deanery,
            UserRoleDto.Teacher => UserRoleType.Teacher,
            UserRoleDto.Student => UserRoleType.Student,
            _ => UserRoleType.None
        };
    }
}
