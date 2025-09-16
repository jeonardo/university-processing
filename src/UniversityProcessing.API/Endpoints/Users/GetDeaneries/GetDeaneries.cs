using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Users.GetDeaneries;

internal sealed class GetDeaneries : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetDeaneries);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<GetDeaneriesRequestDto>>();
    }

    private static async Task<GetDeaneriesResponseDto> Handle(
        [AsParameters] GetDeaneriesRequestDto request,
        [FromServices] IEfReadRepository<Deanery> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x =>
                EF.Functions.Like(x.FullName, $"%{request.Filter}%") &&
                (!request.FacultyId.HasValue || x.FacultyId == request.FacultyId),
            x => new DeaneryDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Approved, x.Blocked, x.UniversityPosition.Name),
            x => x.Include(deanery => deanery.UniversityPosition),
            cancellationToken);
        return new GetDeaneriesResponseDto(pagedList);
    }
}
