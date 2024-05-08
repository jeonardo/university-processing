using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;

namespace UniversityProcessing.DomainServices.Features.Identity.Register;

internal sealed class RegisterCommandRequestHandler(UserManager<User> userManager, ILogger<RegisterCommandRequestHandler> logger)
    : IRequestHandler<RegisterCommandRequest>
{
    public async Task Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        var user = new User(request.UserName, request.FirstName, request.LastName, request.MiddleName, request.Email, request.Birthday);
        var createResult = await userManager.CreateAsync(user, request.Password);
        var setRoleResult = await userManager.AddToRoleAsync(user, request.UserRoleId.ToString());

        // If any failed
        if (!createResult.Succeeded || !setRoleResult.Succeeded)
        {
            if (createResult.Succeeded)
            {
                var deleteResult = await userManager.DeleteAsync(user);

                if (!deleteResult.Succeeded)
                {
                    logger.LogError("Registration failed but user wasn't removed");
                }
            }

            throw new ConflictException(
                $"Registration failed. Message = {string.Join("; ",
                    createResult.Errors,
                    setRoleResult.Errors)}");
        }
    }
}