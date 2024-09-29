using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.Register;

internal sealed class RegisterEmployeeCommandHandler(UserManager<User> userManager, ILogger<RegisterEmployeeCommandHandler> logger)
    : IRequestHandler<RegisterEmployeeCommandRequest>
{
    public async Task Handle(RegisterEmployeeCommandRequest request, CancellationToken cancellationToken)
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

        var addToRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoles.Employee));

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
