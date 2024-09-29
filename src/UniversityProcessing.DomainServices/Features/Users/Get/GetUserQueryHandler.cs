using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Users.Get;

internal sealed class GetUserQueryHandler(UserManager<User> userManager)
    : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
{
    public async Task<GetUserQueryResponse> Handle(
        GetUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        var entity = await userManager.FindByIdAsync(request.Id.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.Id} not found");
        return new GetUserQueryResponse(entity);
    }
}
