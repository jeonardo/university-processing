using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;

internal sealed class RegisterStudentCommandHandler(
    UserManager<User> userManager,
    ILogger<RegisterStudentCommandHandler> logger)
    : IRequestHandler<RegisterStudentCommandRequest>
{
    public async Task Handle(RegisterStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var user = User.CreateStudent(request.UserName, request.FirstName, request.LastName, request.MiddleName, request.Email, request.Birthday, request.GroupId);

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
