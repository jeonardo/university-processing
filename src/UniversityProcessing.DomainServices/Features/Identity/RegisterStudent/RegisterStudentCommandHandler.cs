using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Identity.Enums;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Guards;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;

internal sealed class RegisterStudentCommandHandler(
    UserManager<User> userManager,
    ILogger<RegisterStudentCommandHandler> logger,
    IEfReadRepository<Group> groupRepository)
    : IRequestHandler<RegisterStudentCommandRequest>
{
    public async Task Handle(RegisterStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var group = await groupRepository.GetByIdRequiredAsync(Guard.Against.NullOrDefault(request.GroupId), cancellationToken);
        var user = new User(
            group,
            request.UserName,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday);
        var createStudentResult = await userManager.CreateAsync(user, request.Password);
        var setStudentRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleId.Student));

        // If any failed
        if (!createStudentResult.Succeeded || !setStudentRoleResult.Succeeded)
        {
            if (createStudentResult.Succeeded)
            {
                var deleteResult = await userManager.DeleteAsync(user);

                if (!deleteResult.Succeeded)
                {
                    logger.LogError("Registration failed but user wasn't removed");
                }
            }

            throw new ConflictException(
                $"Registration failed. Message = {string.Join("; ",
                    createStudentResult.Errors,
                    setStudentRoleResult.Errors)}");
        }
    }
}
