using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterAdmin.Register;

internal sealed class RegisterAdmin : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(nameof(RegisterAdmin), Handle)
            .WithTags(Tags.REGISTRATION_ADMIN)
            .AddEndpointFilter<ValidationFilter<RegisterAdminRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RegisterAdminRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ILogger<RegisterAdmin> logger,
        CancellationToken cancellationToken)
    {
        var user = User.CreateAdmin(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday);

        var createResult = await userManager.CreateAsync(user, request.Password);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"Registration failed. Message = {string.Join("; ", createResult.Errors)}");
        }

        var addToRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleType.ApplicationAdmin));

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
