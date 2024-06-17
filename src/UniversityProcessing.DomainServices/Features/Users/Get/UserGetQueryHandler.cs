using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Users.Get.Contracts;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

namespace UniversityProcessing.DomainServices.Features.Users.Get;

internal sealed class UserGetQueryHandler(UserManager<User> userManager)
    : IRequestHandler<UserGetQueryRequest, UserGetQueryResponse>
{
    public async Task<UserGetQueryResponse> Handle(
        UserGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString())
            ?? throw new NotFoundException($"{nameof(User)} with id = {request.Id} not found");

        return new UserGetQueryResponse(UserConverter.ToDto(user));
    }
}
