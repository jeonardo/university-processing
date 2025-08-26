using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Users.GetAdmins;

internal sealed class GetAdmins : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetAdmins);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<GetAdminsRequestDto>>();
    }

    private static async Task<GetAdminsResponseDto> Handle(
        [AsParameters] GetAdminsRequestDto request,
        [FromServices] IEfReadRepository<Admin> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => EF.Functions.Like(x.FullName, $"%{request.Filter}%"),
            x => new AdminDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Approved, x.Blocked),
            null,
            cancellationToken);
        return new GetAdminsResponseDto(pagedList);
    }
}
