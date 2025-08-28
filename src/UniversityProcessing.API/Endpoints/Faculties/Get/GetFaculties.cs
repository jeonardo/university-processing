using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Faculties.Get;

internal sealed class GetFaculties : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetFaculties);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)));
    }

    private static async Task<GetFacultiesResponseDto> Handle(
        [AsParameters] GetFacultiesRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => EF.Functions.Like(x.Name, $"%{request.Filter}%")
                || EF.Functions.Like(x.ShortName, $"%{request.Filter}%"),
            x => new FacultyDto(x.Id, x.Name, x.ShortName),
            null,
            cancellationToken);
        return new GetFacultiesResponseDto(pagedList);
    }
}
