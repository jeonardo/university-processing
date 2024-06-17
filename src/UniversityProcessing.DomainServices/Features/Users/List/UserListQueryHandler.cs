using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Users.List.Contracts;

namespace UniversityProcessing.DomainServices.Features.Users.List;

internal sealed class UserListQueryHandler(UserManager<User> userManager)
    : IRequestHandler<UserListQueryRequest, UserListQueryResponse>
{
    public async Task<UserListQueryResponse> Handle(UserListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await userManager.Users.CountAsync(cancellationToken: cancellationToken);
        var users = userManager.Users
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        //TODO add sorting and filters
        return new UserListQueryResponse(UserConverter.ToPagedDto(users, count, request.PageNumber, request.PageSize));
    }
}
