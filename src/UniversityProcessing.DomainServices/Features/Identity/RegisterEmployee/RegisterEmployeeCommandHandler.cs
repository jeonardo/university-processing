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

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee;

internal sealed class RegisterEmployeeCommandHandler(
    UserManager<User> userManager,
    ILogger<RegisterEmployeeCommandHandler> logger,
    IEfReadRepository<University> universityRepository,
    IEfReadRepository<UniversityPosition> universityPositionRepository)
    : IRequestHandler<RegisterEmployeeCommandRequest>
{
    public async Task Handle(RegisterEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        var university = await universityRepository.GetByIdRequiredAsync(Guard.Against.NullOrDefault(request.UniversityId), cancellationToken);
        var universityPosition = await universityPositionRepository.GetByIdRequiredAsync(
            Guard.Against.NullOrDefault(request.UniversityPositionId),
            cancellationToken);
        var user = new User(
            university,
            universityPosition,
            request.UserName,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday);
        var createEmployeeResult = await userManager.CreateAsync(user, request.Password);
        var setEmployeeRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleId.Employee));

        // If any failed
        if (!createEmployeeResult.Succeeded || !setEmployeeRoleResult.Succeeded)
        {
            if (createEmployeeResult.Succeeded)
            {
                var deleteResult = await userManager.DeleteAsync(user);

                if (!deleteResult.Succeeded)
                {
                    logger.LogError("Registration failed but user wasn't removed");
                }
            }

            throw new ConflictException(
                $"Registration failed. Message = {string.Join("; ",
                    createEmployeeResult.Errors,
                    setEmployeeRoleResult.Errors)}");
        }
    }
}
