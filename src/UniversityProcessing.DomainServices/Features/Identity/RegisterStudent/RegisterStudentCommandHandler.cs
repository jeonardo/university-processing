using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;

internal sealed class RegisterStudentCommandHandler(
    UserManager<User> userManager,
    ILogger<RegisterStudentCommandHandler> logger,
    IEfReadRepository<Group> groupRepository)
    : IRequestHandler<RegisterStudentCommandRequest>
{
    public async Task Handle(RegisterStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var groupId = await GetGroupId();

        var user = User.CreateStudent(request.UserName, request.FirstName, request.LastName, request.MiddleName, request.Email, request.Birthday, groupId);

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

        return;

        async Task<Guid?> GetGroupId()
        {
            if (request.GroupNumber is null)
            {
                return null;
            }

            var group = await groupRepository.FirstOrDefaultAsync(new GroupByNumberSpec(request.GroupNumber), cancellationToken);

            if (group is null)
            {
                throw new NotFoundException($"Group with number {request.GroupNumber} not found");
            }

            return group.Id;
        }
    }
}
