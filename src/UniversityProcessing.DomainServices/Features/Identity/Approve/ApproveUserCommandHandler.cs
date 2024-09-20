using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.Approve;

internal sealed class ApproveUserCommandHandler(UserManager<User> userManager) : IRequestHandler<ApproveUserCommandRequest>
{
    public async Task Handle(ApproveUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.UserId} not found");

        if (user.Approved)
        {
            return;
        }

        user.Approve();

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            throw new ConflictException(updateResult.Errors.ToString() ?? "User wasn't approved");
        }
    }
}
