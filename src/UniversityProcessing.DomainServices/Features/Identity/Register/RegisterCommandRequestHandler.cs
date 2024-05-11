using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Identity.Enums;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;
using UniversityProcessing.GenericSubdomain.Exceptions;
using UniversityProcessing.GenericSubdomain.Guards;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Identity.Register;

internal sealed class RegisterCommandRequestHandler(
    UserManager<User> userManager,
    ILogger<RegisterCommandRequestHandler> logger,
    IEfReadRepository<University> universityRepository,
    IEfReadRepository<UniversityPosition> universityPositionRepository,
    IEfReadRepository<Group> groupRepository)
    : IRequestHandler<RegisterCommandRequest>
{
    public Task Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        switch (request.UserRoleId)
        {
            case UserRoleId.ApplicationAdmin:
                return RegisterAdminAsync(request, cancellationToken);
            case UserRoleId.Employee:
                return RegisterEmployeeAsync(request, cancellationToken);
            case UserRoleId.Student:
                return RegisterStudentAsync(request, cancellationToken);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private async Task RegisterAdminAsync(RegisterCommandRequest request, CancellationToken cancellationToken)
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

    private async Task RegisterEmployeeAsync(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        //TODO must be elements tree is contain validation
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

    private async Task RegisterStudentAsync(RegisterCommandRequest request, CancellationToken cancellationToken)
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