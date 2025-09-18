using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Registration.Common;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Admin;

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

    private static async Task<BaseResponseDto> Handle(
        [FromBody] RequestDto request,
        [FromServices] IRegistrationService registrationService,
        CancellationToken cancellationToken)
    {
        var userId = await registrationService.Register(request, UserRoleType.Admin, cancellationToken);
        return new BaseResponseDto(userId);
    }
}
