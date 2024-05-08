using Ardalis.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Universities.SetAdmin.Contracts;

namespace UniversityProcessing.DomainServices.Features.Universities.SetAdmin;

internal sealed class UniversitySetAdminCommandHandler(
    IRepository<University> repository,
    UserManager<User> userManager) : IRequestHandler<UniversitySetAdminCommandRequest>
{
    public async Task Handle(UniversitySetAdminCommandRequest request, CancellationToken cancellationToken)
    {
        var university = await repository.GetByIdAsync(request.UniversityId, cancellationToken)
            ?? throw new NotFoundException($"{nameof(University)} with id = {request.UniversityId} not found");

        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.UserId} not found");

        university.SetAdmin(user);

        var resultCode = await repository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(UniversitySetAdminCommandRequest)} failed");
        }
    }
}