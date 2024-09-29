using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Users.GetList;

internal sealed class GetUsersQueryHandler(UserManager<User> userManager)
    : IRequestHandler<GetUsersQueryRequest, GetUsersQueryResponse>
{
    public async Task<GetUsersQueryResponse> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await userManager.Users.CountAsync(cancellationToken: cancellationToken);
        var users = userManager.Users
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        //TODO add sorting and filters
        return new GetUsersQueryResponse(new PagedList<User>(users, count, request.PageNumber, request.PageSize));
    }
}
