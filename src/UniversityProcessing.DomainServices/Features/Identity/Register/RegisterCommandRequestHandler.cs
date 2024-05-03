using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;
using UniversityProcessing.DomainServices.Features.Identity.Register.Converters;

namespace UniversityProcessing.DomainServices.Features.Identity.Register;

public sealed class RegisterCommandRequestHandler(UserManager<User> userManager) : IRequestHandler<RegisterCommandRequest>
{
    public async Task Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        var user = UserConverter.ToDomain(request);
        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return;
        }

        throw new ConflictException($"Registration failed. Message = {result.Errors}");
    }
}