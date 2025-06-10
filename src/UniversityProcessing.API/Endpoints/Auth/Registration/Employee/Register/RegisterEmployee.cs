using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.GenericSubdomain.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Employee.Register;

internal sealed class RegisterEmployee : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(RegisterEmployee);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RegisterEmployeeRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RegisterEmployeeRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ILogger<RegisterEmployee> logger,
        CancellationToken cancellationToken)
    {
        var user = User.CreateEmployee(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday,
            request.UniversityPositionId);

        var createResult = await userManager.CreateAsync(user, request.Password);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"Registration failed. Message = {createResult.FullDescription()}");
        }

        var addToRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleType.Employee));

        if (addToRoleResult.IsFailed())
        {
            var deleteResult = await userManager.DeleteAsync(user);

            if (deleteResult.IsFailed())
            {
                logger.LogError("Registration failed but user wasn't removed");
            }

            throw new ConflictException($"Registration failed. Message = {addToRoleResult.FullDescription()}");
        }
    }
}
