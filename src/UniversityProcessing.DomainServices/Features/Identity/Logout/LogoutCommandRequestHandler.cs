using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Identity.Logout.Contracts;

namespace UniversityProcessing.DomainServices.Features.Identity.Logout;

internal sealed class LogoutCommandRequestHandler(SignInManager<User> signInManager) : IRequestHandler<LogoutCommandRequest>
{
    public Task Handle(LogoutCommandRequest request, CancellationToken cancellationToken)
    {
        return signInManager.SignOutAsync();
    }
}