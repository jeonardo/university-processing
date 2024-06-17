using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Identity.Enums;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterAdmin;

internal sealed class RegisterAdminCommandHandler(
    UserManager<User> userManager,
    ILogger<RegisterAdminCommandHandler> logger)
    : IRequestHandler<RegisterAdminCommandRequest>
{
    public async Task Handle(RegisterAdminCommandRequest request, CancellationToken cancellationToken)
    {
        var user = new User(request.UserName, request.FirstName, request.LastName, request.MiddleName, request.Email, request.Birthday);
        var createUserResult = await userManager.CreateAsync(user, request.Password);
        var setApplicationAdminRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleId.ApplicationAdmin));

        // If any failed
        if (!createUserResult.Succeeded || !setApplicationAdminRoleResult.Succeeded)
        {
            if (createUserResult.Succeeded)
            {
                var deleteResult = await userManager.DeleteAsync(user);

                if (!deleteResult.Succeeded)
                {
                    logger.LogError("Registration failed but user wasn't removed");
                }
            }

            throw new ConflictException(
                $"Registration failed. Message = {string.Join("; ",
                    createUserResult.Errors,
                    setApplicationAdminRoleResult.Errors)}");
        }
    }
}
