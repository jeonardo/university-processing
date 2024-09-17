using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Identity.Delete;

internal sealed class UserDeleteCommandHandler(UserManager<User> userManager) : IRequestHandler<UserDeleteCommandRequest>
{
    public async Task Handle(UserDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.Id} not found");

        var result = await userManager.DeleteAsync(user);
    }
}
