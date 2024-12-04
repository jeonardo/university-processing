using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterEmployee.Register;

internal sealed class RegisterEmployee : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(nameof(RegisterEmployee), Handle)
            .WithTags(Tags.REGISTRATION_EMPLOYEE)
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
            request.UniversityId,
            request.UniversityPositionId);

        var createResult = await userManager.CreateAsync(user, request.Password);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"Registration failed. Message = {string.Join("; ", createResult.Errors)}");
        }

        var addToRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleType.Employee));

        if (addToRoleResult.IsFailed())
        {
            var deleteResult = await userManager.DeleteAsync(user);

            if (deleteResult.IsFailed())
            {
                logger.LogError("Registration failed but user wasn't removed");
            }

            throw new ConflictException($"Registration failed. Message = {string.Join("; ", addToRoleResult.Errors)}");
        }
    }
}
