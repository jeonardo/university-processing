using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.UpdateIsApprovedStatus;

internal sealed class UpdateIsApprovedStatusCommandHandler(UserManager<User> userManager) : IRequestHandler<UpdateIsApprovedStatusCommandRequest>
{
    public async Task Handle(UpdateIsApprovedStatusCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.UserId} not found");

        user.UpdateIsApprovedStatus(request.IsApproved);

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            throw new ConflictException(updateResult.Errors.ToString() ?? "User status wasn't changed");
        }
    }
}
