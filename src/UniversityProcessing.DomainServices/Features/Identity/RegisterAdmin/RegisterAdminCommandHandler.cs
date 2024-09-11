using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterAdmin;

internal sealed class RegisterAdminCommandHandler(UserManager<User> userManager, ILogger<RegisterAdminCommandHandler> logger)
    : IRequestHandler<RegisterAdminCommandRequest>
{
    public async Task Handle(RegisterAdminCommandRequest request, CancellationToken cancellationToken)
    {
        var user = User.CreateAdmin(request.UserName, request.FirstName, request.LastName, request.MiddleName, request.Email, request.Birthday);

        var createResult = await userManager.CreateAsync(user, request.Password);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"Registration failed. Message = {string.Join("; ", createResult.Errors)}");
        }

        var addToRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoles.ApplicationAdmin));

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
