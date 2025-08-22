using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Auth.Registration.Common;
using UniversityProcessing.API.Endpoints.Auth.Registration.Register.Teacher;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Student;

internal sealed class RegisterStudent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(RegisterStudent);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RegisterTeacherRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RegisterStudentRequestDto request,
        [FromServices] IRegistrationService registrationService,
        CancellationToken cancellationToken)
    {
        await registrationService.Register(request, UserRoleType.Student, cancellationToken);
    }
}
