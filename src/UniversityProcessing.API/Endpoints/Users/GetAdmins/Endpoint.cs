using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetAdmins;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfReadRepository<Admin> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => EF.Functions.Like(x.FullName, $"%{request.Filter}%"),
            x => new AdminDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Approved, x.Blocked),
            null,null,
            cancellationToken);
        return new ResponseDto(pagedList);
    }
}
