using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Auth.Registration.Common;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Deanery;

internal sealed class RegisterDeanery : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(RegisterDeanery);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RegisterDeaneryRequestDto>>();
    }

    private static async Task<RegisterResponseDto> Handle(
        [FromBody] RegisterDeaneryRequestDto request,
        [FromServices] IRegistrationService registrationService,
        CancellationToken cancellationToken)
    {
        var userId = await registrationService.Register(request, UserRoleType.Deanery, cancellationToken);
        return new RegisterResponseDto(userId);
    }
}
